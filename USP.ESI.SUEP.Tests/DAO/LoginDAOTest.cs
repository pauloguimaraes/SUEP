using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using USP.ESI.SUEP.Dao;
using System;
using System.Data.Entity;

namespace USP.ESI.SUEP.Tests.DAO
{
    [TestClass]
    public class LoginDAOTest
    {
        private Mock<EntidadesContext> mock;

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
            
            var _objMockSet = GetMockUserSet(_dataUser);
            _objMockSet.Setup(m => m.Include(It.IsAny<string>())).Returns(_objMockSet.Object);
            
            mock.Setup(c => c.Users).Returns(_objMockSet.Object);
        }

        private Mock<DbSet<TbSuep_User>> GetMockUserSet(IQueryable<TbSuep_User> data)
        {
            var _objMockSet = new Mock<DbSet<TbSuep_User>>();
            _objMockSet.As<IQueryable<TbSuep_User>>()
                .Setup(m => m.Provider).Returns(data.Provider);
            _objMockSet.As<IQueryable<TbSuep_User>>()
                .Setup(m => m.Expression).Returns(data.Expression);
            _objMockSet.As<IQueryable<TbSuep_User>>()
                .Setup(m => m.ElementType).Returns(data.ElementType);
            _objMockSet.As<IQueryable<TbSuep_User>>()
                .Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return _objMockSet;
        }

        [TestMethod]
        public void ShouldBeAbleToAuthenticate()
        {
            var _strUser = "paulo";
            var _strPass = "123456";

            var _objDao = new LoginDAO(mock.Object);
            Assert.AreEqual(_objDao.Auth(_strUser, _strPass).Id, 1);
        }

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
    }
}
