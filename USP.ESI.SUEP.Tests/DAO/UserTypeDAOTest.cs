using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using USP.ESI.SUEP.Dao;
using USP.ESI.SUEP.Tests.Util;

namespace USP.ESI.SUEP.Tests.Mock.DAOTests
{
    /// <summary>
    /// Classe de testes para interações com a camada de DAO dos tipos de usuário
    /// </summary>
    /// 
    /// <author>
    /// Carlos F Traldi, 9390322
    /// Paulo H F Guimaraes, 9390361
    /// Pedro A Minutentag, 7994580
    /// </author>
    [TestClass]
    public class UserTypeDAOTest
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

            var setMock = MockUtil<TbSuep_User_Type>.GetMockSet(data);
            entitiesMock.Setup(c => c.UserTypes).Returns(setMock.Object);
        }
        
        #endregion
        
        #region [Tests]

        /// <summary>
        /// Caso de teste para uma lista já preenchida
        /// </summary>
        [TestMethod]
        public void ShouldGetAllList()
        {
            Assert.AreEqual(new UserTypeDAO(entitiesMock.Object).Get().Count, 2);
        }


        /// <summary>
        /// Caso de teste para quando a lista é vazia
        /// </summary>
        [TestMethod]
        public void ShouldThrowExceptionIfListIsEmpty()
        {
            entitiesMock.Setup(c => c.UserTypes).Returns(
                MockUtil<TbSuep_User_Type>.GetMockSet(new List<TbSuep_User_Type>().AsQueryable()).Object);
            
            Assert.ThrowsException<Exception>(() => {
                new UserTypeDAO(entitiesMock.Object).Get();
            });
        }

        #endregion

    }
}
