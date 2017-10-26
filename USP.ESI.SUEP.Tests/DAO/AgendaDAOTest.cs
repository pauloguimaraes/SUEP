using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using USP.ESI.SUEP.Dao;

namespace USP.ESI.SUEP.Tests.DAO
{
    [TestClass]
    public class AgendaDAOTest
    {
        private Mock<EntidadesContext> mock;

        [TestInitialize]
        public void Setup()
        {
            mock = new Mock<EntidadesContext>();
        }

        [TestMethod]
        public void ShouldGetAgenda()
        {
            var data = new List<TbSuep_Agenda>()
            {
                new TbSuep_Agenda()
                {
                    Id = 1,
                    Dt_Begin = DateTime.Now.AddHours(-1),
                    Dt_End = DateTime.Now,
                    Id_User_Doctor = 1,
                    Id_User_Pacient = 2
                }, new TbSuep_Agenda()
                {
                    Id = 1,
                    Dt_Begin = DateTime.Now.AddHours(-1),
                    Dt_End = DateTime.Now,
                    Id_User_Doctor = 3,
                    Id_User_Pacient = 4
                }
            }.AsQueryable();

            var _objMockSet = GetMockSet(data);
            _objMockSet.Setup(m => m.Include(It.IsAny<string>())).Returns(_objMockSet.Object);
            mock.Setup(c => c.Agendas).Returns(_objMockSet.Object);

            var _objDao = new AgendaDAO(mock.Object);
            Assert.AreEqual(1, _objDao.Get(1).Count);
        }

        [TestMethod]
        public void ShouldReturnEmptyList()
        {
            var data = new List<TbSuep_Agenda>()
            {
                new TbSuep_Agenda()
                {
                    Id = 1,
                    Dt_Begin = DateTime.Now.AddHours(-1),
                    Dt_End = DateTime.Now,
                    Id_User_Doctor = 1,
                    Id_User_Pacient = 2
                }
            }.AsQueryable();

            var _objMockSet = GetMockSet(data);
            _objMockSet.Setup(m => m.Include(It.IsAny<string>())).Returns(_objMockSet.Object);
            mock.Setup(c => c.Agendas).Returns(_objMockSet.Object);

            var _objDao = new AgendaDAO(mock.Object);
            Assert.AreEqual(_objDao.Get(100).Count, 0);
        }

        [TestMethod]
        public void ShouldBeAbleToAddAgendaWithoutConflict()
        {
            var data = new List<TbSuep_Agenda>()
            {
                new TbSuep_Agenda()
                {
                    Id = 1,
                    Dt_Begin = DateTime.Now.AddHours(-1),
                    Dt_End = DateTime.Now,
                    Id_User_Doctor = 1,
                    Id_User_Pacient = 2
                }
            }.AsQueryable();

            var _objMockSet = GetMockSet(data);
            _objMockSet.Setup(m => m.Include(It.IsAny<string>())).Returns(_objMockSet.Object);
            mock.Setup(c => c.Agendas).Returns(_objMockSet.Object);

            Assert.IsTrue(new AgendaDAO(mock.Object).Add(new TbSuep_Agenda()
            {
                Id_User_Doctor = 1,
                Id_User_Pacient = 2,
                Dt_Begin = DateTime.Now.AddHours(-4),
                Dt_End = DateTime.Now.AddHours(-3),
            }));
        }

        private Mock<DbSet<TbSuep_Agenda>> GetMockSet(IQueryable<TbSuep_Agenda> data)
        {
            var _objMockSet = new Mock<DbSet<TbSuep_Agenda>>();
            _objMockSet.As<IQueryable<TbSuep_Agenda>>()
                .Setup(m => m.Provider).Returns(data.Provider);
            _objMockSet.As<IQueryable<TbSuep_Agenda>>()
                .Setup(m => m.Expression).Returns(data.Expression);
            _objMockSet.As<IQueryable<TbSuep_Agenda>>()
                .Setup(m => m.ElementType).Returns(data.ElementType);
            _objMockSet.As<IQueryable<TbSuep_Agenda>>()
                .Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return _objMockSet;
        }
    }
}
