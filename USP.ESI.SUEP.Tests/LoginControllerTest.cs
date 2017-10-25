using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using USP.ESI.SUEP.Lib.Controller;
using USP.ESI.SUEP.Lib.Model;

namespace USP.ESI.SUEP.Tests
{
    [TestClass]
    public class LoginControllerTest
    {
        private LoginController _objLoginController;

        [TestInitialize]
        public void Setup()
        {
            _objLoginController = new LoginController();
        }

        [TestMethod]
        public void ShouldRetrieveExistentUser()
        {
            Assert.AreEqual(_objLoginController.Auth(new User("paulo", "123456")), new User("paulo", "123456"));
        }

        [TestMethod]
        public void ShouldThrowAExceptionIfDoesNotExists()
        {
            Assert.ThrowsException<NullReferenceException>(() => {
                _objLoginController.Auth(new User("pao_de_batata", "eba"));
            });
        }
    }
}
