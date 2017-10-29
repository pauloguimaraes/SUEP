using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using USP.ESI.SUEP.Dao;
using System;
using USP.ESI.SUEP.Tests.Util;

namespace USP.ESI.SUEP.Tests.DAO
{
    /// <summary>
    /// Classe de testes para interações com a camada de DAO do login
    /// </summary>
    /// 
    /// <author>
    /// Carlos F Traldi, 9390322
    /// Paulo H F Guimaraes, 9390361
    /// Pedro A Minutentag, 7994580
    /// </author>
    [TestClass]
    public class LoginDAOTest
    {
        private Mock<EntidadesContext> mock;

        #region [Init]

        /// <summary>
        /// Inicialização dos casos de teste
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            mock = new Mock<EntidadesContext>();
            
            var _dataUser = new List<TbSuep_User>()
            {
                new TbSuep_User()
                {
                    Id = 1,
                    Login = "paulo",
                    Pass = "123456"
                },
                new TbSuep_User()
                {
                    Id = 2,
                    Login = "test",
                    Pass = "abc123"
                }
            }.AsQueryable();
            
            var _objMockSet = MockUtil<TbSuep_User>.GetMockSet(_dataUser);
            _objMockSet.Setup(m => m.Include(It.IsAny<string>())).Returns(_objMockSet.Object);
            
            mock.Setup(c => c.Users).Returns(_objMockSet.Object);
        }
        
        #endregion

        #region [Tests]

        /// <summary>
        /// Caso de teste para o login bem sucedido
        /// </summary>
        [TestMethod]
        public void ShouldBeAbleToAuthenticate()
        {
            var _strUser = "paulo";
            var _strPass = "123456";

            var _objDao = new LoginDAO(mock.Object);
            Assert.AreEqual(_objDao.Auth(_strUser, _strPass).Id, 1);
        }


        /// <summary>
        /// Caso de teste para quando o login falha
        /// </summary>
        [TestMethod]
        public void ShouldThrowExceptionIfAuthenticationFails()
        {
            var _strUser = "paulo";
            var _strPass = "epa";

            var _objDao = new LoginDAO(mock.Object);
            Assert.ThrowsException<Exception>(() =>
            {
                _objDao.Auth(_strUser, _strPass);
            });
        }


        /// <summary>
        /// Caso de teste para quando o usuário não existe
        /// </summary>
        [TestMethod]
        public void ShouldThrowExceptionIfUserDoesNotExists()
        {
            var _strUser = "inexistente";
            var _strPass = "epa";

            var _objDao = new LoginDAO(mock.Object);
            Assert.ThrowsException<Exception>(() =>
            {
                _objDao.Auth(_strUser, _strPass);
            });
        }

        #endregion

    }
}
