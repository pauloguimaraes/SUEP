using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using USP.ESI.SUEP.Dao;

namespace USP.ESI.SUEP.Tests.Mock.DAOTests
{
    [TestClass]
    public class UserTypeDAOTest
    {
        private Mock<EntidadesContext> mock;

        [TestInitialize]
        public void Setup()
        {
            mock = new Mock<EntidadesContext>();
        }

        [TestMethod]
        public void ShouldGetAllList()
        {
            var data = new List<TbSuep_User_Type>()
            {
                new TbSuep_User_Type()
                {
                    Id = 1,
                    UserType = "Teste"
                },
                new TbSuep_User_Type()
                {
                    Id = 2,
                    UserType = "Teste2"
                }
            }.AsQueryable();
            var _objMockSet = GetMockSet(data);

            mock.Setup(c => c.UserTypes).Returns(_objMockSet.Object);

            var _objDao = new UserTypeDAO(mock.Object);
            var _lstRecuperada = _objDao.Get();

            Assert.AreEqual(_lstRecuperada.Count, 2);
        }

        [TestMethod]
        public void ShouldThrowExceptionIfListIsEmpty()
        {
            var data = new List<TbSuep_User_Type>().AsQueryable();
            var _objMockSet = GetMockSet(data);

            mock.Setup(c => c.UserTypes).Returns(_objMockSet.Object);
            mock.Setup(c => c.SaveChanges()).Callback(() => { });

            var _objDao = new UserTypeDAO(mock.Object);

            Assert.ThrowsException<Exception>(() => {
                _objDao.Get();
            });
        }
        
        private Mock<DbSet<TbSuep_User_Type>> GetMockSet(IQueryable<TbSuep_User_Type> data)
        {
            var _objMockSet = new Mock<DbSet<TbSuep_User_Type>>();
            _objMockSet.As<IQueryable<TbSuep_User_Type>>()
                .Setup(m => m.Provider).Returns(data.Provider);
            _objMockSet.As<IQueryable<TbSuep_User_Type>>()
                .Setup(m => m.Expression).Returns(data.Expression);
            _objMockSet.As<IQueryable<TbSuep_User_Type>>()
                .Setup(m => m.ElementType).Returns(data.ElementType);
            _objMockSet.As<IQueryable<TbSuep_User_Type>>()
                .Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return _objMockSet;
        }
    }
}
