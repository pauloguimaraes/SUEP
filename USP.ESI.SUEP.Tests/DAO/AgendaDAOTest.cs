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
    /// Classe de testes para interações com a camada de DAO da agenda
    /// </summary>
    /// 
    /// <author>
    /// Carlos F Traldi, 9390322
    /// Paulo H F Guimaraes, 9390361
    /// Pedro A Minutentag, 7994580
    /// </author>
    [TestClass]
    public class AgendaDAOTest
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

            var data = new List<TbSuep_Agenda>()
            {
                new TbSuep_Agenda()
                {
                    Id = 1,
                    Dt_Begin = DateTime.Now.AddMinutes(-30),
                    Dt_End = DateTime.Now.AddMinutes(30),
                    Id_User_Doctor = 1,
                    Id_User_Pacient = 2
                },
                new TbSuep_Agenda()
                {
                    Id = 3,
                    Dt_Begin = DateTime.Now.AddHours(-2),
                    Dt_End = DateTime.Now.AddHours(-1),
                    Id_User_Doctor = 1,
                    Id_User_Pacient = 5
                },
                new TbSuep_Agenda()
                {
                    Id = 2,
                    Dt_Begin = DateTime.Now.AddDays(-1).AddHours(-1),
                    Dt_End = DateTime.Now.AddDays(-1),
                    Id_User_Doctor = 3,
                    Id_User_Pacient = 4
                }
            }.AsQueryable();

            var _objSetMock = MockUtil<TbSuep_Agenda>.GetMockSet(data);
            _objSetMock.Setup(m => m.Include(It.IsAny<string>())).Returns(_objSetMock.Object);
            entitiesMock.Setup(c => c.Agendas).Returns(_objSetMock.Object);
        }

        #endregion


        #region [Tests]

        /// <summary>
        /// Caso de teste de recuperação da agenda de um médico específico
        /// </summary>
        [TestMethod]
        public void ShouldGetAgendaFromASpecificDoctor()
        {
            Assert.AreEqual(2, new AgendaDAO(entitiesMock.Object).Get(1).Count);
        }


        /// <summary>
        /// Caso de teste onde tenta-se recuperar a agenda de um médico inexistente
        /// </summary>
        [TestMethod]
        public void ShouldThrowExceptionIfDoctorDoesNotExists()
        {
            Assert.ThrowsException<Exception>(() => {
                new AgendaDAO(entitiesMock.Object).Get(100);
            });
        }


        /// <summary>
        /// Caso de teste onde tenta-se adicionar um agendamento sem conflitos
        /// </summary>
        [TestMethod]
        public void ShouldBeAbleToAddAgendaWithoutConflict()
        {
            Assert.IsTrue(new AgendaDAO(entitiesMock.Object).Add(new TbSuep_Agenda()
            {
                Id_User_Doctor = 1,
                Id_User_Pacient = 2,
                Dt_Begin = DateTime.Now.AddHours(-4),
                Dt_End = DateTime.Now.AddHours(-3)
            }));
        }


        /// <summary>
        /// Caso de testes onde tenta-se adicionar um agendamento com conflitos
        /// </summary>
        [TestMethod]
        public void ShouldNotBeAbleToAddAgendaWithConflictToSameDoctor()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                new AgendaDAO(entitiesMock.Object).Add(new TbSuep_Agenda()
                {
                    Id_User_Doctor = 1,
                    Id_User_Pacient = 2,
                    Dt_Begin = DateTime.Now.AddMinutes(-30),
                    Dt_End = DateTime.Now.AddHours(30)
                });
            });
        }


        /// <summary>
        /// Caso de testes onde tenta-se adicionar um agendamento com conflito com outro doutor
        /// </summary>
        [TestMethod]
        public void ShouldBeAbleToAddAgendaWithConflictWithAnotherDoctor()
        {
            Assert.IsTrue(new AgendaDAO(entitiesMock.Object).Add(new TbSuep_Agenda()
            {
                Id_User_Doctor = 3,
                Id_User_Pacient = 4,
                Dt_Begin = DateTime.Now.AddMinutes(-30),
                Dt_End = DateTime.Now.AddMinutes(30)
            }));
        }


        /// <summary>
        /// Caso de testes onde tenta-se editar um agendamento sem conflitos com outros agendamentos
        /// </summary>
        [TestMethod]
        public void ShouldBeAbleToEditAgendaResultingNoConflictWithSameDoctor()
        {
            Assert.IsTrue(new AgendaDAO(entitiesMock.Object).Edit(new TbSuep_Agenda()
            {
                Id = 1,
                Id_User_Doctor = 1,
                Id_User_Pacient = 2,
                Dt_Begin = DateTime.Now.AddHours(-4),
                Dt_End = DateTime.Now.AddHours(-4)
            }));
        }


        /// <summary>
        /// Caso de testes onde tenta-se editar um agendamento gerando conflitos com outro médico
        /// </summary>
        [TestMethod]
        public void ShouldBeAbleToEditAgendaResultingConflictWithAnotherDoctor()
        {
            Assert.IsTrue(new AgendaDAO(entitiesMock.Object).Edit(new TbSuep_Agenda()
            {
                Id = 2,
                Dt_Begin = DateTime.Now.AddHours(-30),
                Dt_End = DateTime.Now.AddHours(30),
                Id_User_Doctor = 3,
                Id_User_Pacient = 4
            }));
        }


        /// <summary>
        /// Caso de testes onde edita-se um agendamento gerando conflitos com outros agendamentos do mesmo médico
        /// </summary>
        [TestMethod]
        public void ShouldNotBeAbleToEditAgendaResultingConflictWithSameDoctor()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                new AgendaDAO(entitiesMock.Object).Edit(new TbSuep_Agenda()
                {
                    Id = 3,
                    Dt_Begin = DateTime.Now.AddHours(-1).AddMinutes(-30),
                    Dt_End = DateTime.Now.AddMinutes(-30),
                    Id_User_Doctor = 1,
                    Id_User_Pacient = 5
                });
            });
        }


        /// <summary>
        /// Caso de testes onde tenta-se apagar um agendamento
        /// </summary>
        [TestMethod]
        public void ShouldBeAbleToDeleteAnExistentAgenda()
        {
            Assert.IsTrue(new AgendaDAO(entitiesMock.Object).Remove(new TbSuep_Agenda()
            {
                Id = 1
            }));
        }


        /// <summary>
        /// Caso de testes onde tenta-se apagar um agendamento que já aconteceu
        /// </summary>
        [TestMethod]
        public void ShouldNotBeAbleToDeletePastAgendas()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                new AgendaDAO(entitiesMock.Object).Remove(new TbSuep_Agenda()
                {
                    Id = 2
                });
            });
        }

        #endregion

    }
}
