using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using USP.ESI.SUEP.Dao;
using USP.ESI.SUEP.Tests.Util;

namespace USP.ESI.SUEP.Tests.DAO
{
    /// <summary>
    /// Classe de testes para interações com a camada de DAO do usuário
    /// </summary>
    /// 
    /// <author>
    /// Carlos F Traldi, 9390322
    /// Paulo H F Guimaraes, 9390361
    /// Pedro A Minutentag, 7994580
    /// </author>
    [TestClass]
    public class UserDAOTest
    {
        private Mock<EntidadesContext> entitiesMock;


        #region [Init]

        /// <summary>
        /// Inicialização dos casos de teste
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            entitiesMock = new Mock<EntidadesContext>();

            var data = new List<TbSuep_User>()
            {
                new TbSuep_User()
                {
                    Id = 1,
                    CPF = "40196138850",
                    FlActive = true,
                    Id_User_Type = 1,
                    Login = "aaa",
                    Pass = "123456",
                    Name = "Paulo"
                },
                new TbSuep_User()
                {
                    Id = 2,
                    CPF = "12345678900",
                    FlActive = true,
                    Id_User_Type = 2,
                    Login = "bbb",
                    Pass = "123456",
                    Name = "Usuario de teste"
                },
                new TbSuep_User()
                {
                    Id = 3,
                    CPF = "45612378900",
                    FlActive = true,
                    Id_User_Type = 3,
                    Login = "ccc",
                    Pass = "123456",
                    Name = "Outro usuario de teste"
                },
                new TbSuep_User()
                {
                    Id = 4,
                    CPF = "00000000000",
                    FlActive = false,
                    Id_User_Type = 1,
                    Login = "eee",
                    Pass = "123456",
                    Name = "Admin inativo"
                },
                new TbSuep_User()
                {
                    Id = 5,
                    CPF = "11111111111",
                    FlActive = false,
                    Id_User_Type = 2,
                    Login = "ddd",
                    Pass = "123456",
                    Name = "Medico inativo"
                },
                new TbSuep_User()
                {
                    Id = 6,
                    CPF = "22222222222",
                    FlActive = false,
                    Id_User_Type = 3,
                    Login = "abc",
                    Pass = "123456",
                    Name = "Paciente inativo"
                }
            }.AsQueryable();

            var _objSetMock = MockUtil<TbSuep_User>.GetMockSet(data);
            _objSetMock.Setup(m => m.Include(It.IsAny<string>())).Returns(_objSetMock.Object);
            entitiesMock.Setup(c => c.Users).Returns(_objSetMock.Object);
        }

        #endregion


        #region [Tests]

        /// <summary>
        /// Caso de testes da recuperação da lista de usuários
        /// </summary>
        [TestMethod]
        public void ShouldReturn50FirstUsers()
        {
            Assert.IsTrue(new UserDAO(entitiesMock.Object).Get().Count < 50);
        }


        /// <summary>
        /// Caso de testes para quando não há nenhum usuário cadastrado
        /// </summary>
        [TestMethod]
        public void ShouldThrowExceptionIfNoUsersIsRegistered()
        {
            entitiesMock.Setup(m => m.Users).Returns(MockUtil<TbSuep_User>.GetMockSet(new List<TbSuep_User>().AsQueryable()).Object);
            Assert.ThrowsException<Exception>(() =>
            {
                new UserDAO(entitiesMock.Object).Get();
            });
        }
        

        /// <summary>
        /// Caso de testes para garantir que a lista de usuários está ordenada pelo login
        /// </summary>
        [TestMethod]
        public void UsersListShouldBeSortedByLogin()
        {
            var _objDao = new UserDAO(entitiesMock.Object).Get();

            Assert.IsTrue(_objDao[0].Login.Equals("aaa"));
            Assert.IsTrue(_objDao[1].Login.Equals("abc"));
            Assert.IsTrue(_objDao[2].Login.Equals("bbb"));
            Assert.IsTrue(_objDao[3].Login.Equals("ccc"));
            Assert.IsTrue(_objDao[4].Login.Equals("ddd"));
            Assert.IsTrue(_objDao[5].Login.Equals("eee"));
        }


        /// <summary>
        /// Caso de testes para garantir que apenas pacientes estão retornando na lista de pacientes
        /// </summary>
        [TestMethod]
        public void ShouldGetOnlyPacients()
        {
            var _objDao = new UserDAO(entitiesMock.Object).GetAllPacients();

            var _bol = true;
            foreach (var _obj in _objDao)
                if (_obj.Id_User_Type != 3)
                    _bol = false;

            Assert.IsTrue(_bol);
        }


        /// <summary>
        /// Caso de testes para garantir que apenas pacientes ativos estão retornando na lista de pacientes
        /// </summary>
        [TestMethod]
        public void ShouldGetAllActivePacients()
        {
            var _objDao = new UserDAO(entitiesMock.Object).GetAllPacients();
            var _lstBase = entitiesMock.Object.Users.Where(o => o.Id_User_Type == 3 && o.FlActive);

            var _bol = true;
            foreach (var _obj in _lstBase)
                if (!_objDao.Contains(_obj))
                    _bol = false;

            foreach (var _obj in _objDao)
                if (!_lstBase.Contains(_obj))
                    _bol = false;

            Assert.IsTrue(_bol);
        }
        

        /// <summary>
        /// Caso de testes para exclusão de um usuário
        /// </summary>
        [TestMethod]
        public void ShouldBeAbleToDeleteAUser()
        {
            var _bol = entitiesMock.Object.Users.FirstOrDefault(u => u.Id == 1).FlActive;
            Assert.IsTrue(_bol);

            _bol = new UserDAO(entitiesMock.Object).Delete(new TbSuep_User()
            {
                Id = 1
            });
            Assert.IsTrue(_bol);

            _bol = !entitiesMock.Object.Users.FirstOrDefault(u => u.Id == 1).FlActive;
            Assert.IsTrue(_bol);
        }


        /// <summary>
        /// Caso de testes para uando tenta-se excluir um usuário que não existe
        /// </summary>
        [TestMethod]
        public void ShouldThrowExceptionWhenTryToDeleteInexistentUser()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                new UserDAO(entitiesMock.Object).Delete(new TbSuep_User()
                {
                    Id = 150
                });
            });
        }


        /// <summary>
        /// Caso de testes para recuperar um usuário específico
        /// </summary>
        [TestMethod]
        public void ShouldGetSpecificUser()
        {
            var _strUserName = "Paulo";

            Assert.AreEqual(1, new UserDAO(entitiesMock.Object).GetUserWithTheName(_strUserName).Id);
        }


        /// <summary>
        /// Caso de testes para quando tenta-se recuperar um usuário que não existe
        /// </summary>
        [TestMethod]
        public void ShouldThrowExceptionWhenTryToGetInexistentUser()
        {
            var _strName = "Usuário inexistente";

            Assert.ThrowsException<Exception>(() =>
            {
                new UserDAO(entitiesMock.Object).GetUserWithTheName(_strName);
            });
        }


        /// <summary>
        /// Caso de testes para quando se adiciona um usuário
        /// </summary>
        [TestMethod]
        public void ShouldBeAbleToAddANewUser()
        {
            Assert.IsTrue(new UserDAO(entitiesMock.Object).Add(new TbSuep_User()
            {
                Id = 2,
                CPF = "99999999999",
                FlActive = true,
                Id_User_Type = 1,
                Login = "hhh",
                Name = "Novo usuario",
                Pass = "senha"
            }));
        }


        /// <summary>
        /// Caso de testes para quando tenta-se editar um usuário existente
        /// </summary>
        [TestMethod]
        public void ShouldBeAbleToEditUser()
        {
            var _objFirstUser = entitiesMock.Object.Users.FirstOrDefault(u => u.Id == 1);
            Assert.IsNotNull(_objFirstUser);

            var _strName = "Paulo";
            Assert.AreEqual(_strName, _objFirstUser.Name);

            var _strLogin = "aaa";
            Assert.AreEqual(_strLogin, _objFirstUser.Login);

            var _strSenha = "123456";
            Assert.AreEqual(_strSenha, _objFirstUser.Pass);

            var _strCpf = "40196138850";
            Assert.AreEqual(_strCpf, _objFirstUser.CPF);

            var _flgActive = true;
            Assert.AreEqual(_flgActive, _objFirstUser.FlActive);

            var _intIdUserType = 1;
            Assert.AreEqual(_intIdUserType, _objFirstUser.Id_User_Type);

            _strName = "Paulo Guimaraes";
            _objFirstUser.Name = _strName;

            var _bol = new UserDAO(entitiesMock.Object).Update(_objFirstUser);
            Assert.IsTrue(_bol);

            _objFirstUser = entitiesMock.Object.Users.FirstOrDefault(u => u.Id == 1);
            Assert.IsNotNull(_objFirstUser);
            Assert.AreEqual(_strName, _objFirstUser.Name);
        }

        
        /// <summary>
        /// Caso de testes para quando tenta-se editar um usuário inexistente
        /// </summary>
        [TestMethod]
        public void ShouldThrowExceptionWhenTryToEditInexistentUser()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                new UserDAO(entitiesMock.Object).Update(new TbSuep_User()
                {
                    Id = 150
                });
            });
        }

        #endregion

    }
}
