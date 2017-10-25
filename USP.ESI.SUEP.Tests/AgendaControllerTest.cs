using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using USP.ESI.SUEP.Lib;
using USP.ESI.SUEP.Lib.Model;

namespace USP.ESI.SUEP.Tests
{
    [TestClass]
    public class AgendaControllerTest
    {
        private AgendaController _objController;

        [TestInitialize]
        public void Setup()
        {
            _objController = new AgendaController();
        }

        [TestMethod]
        public void ShouldRetrieveAgendaFromADoctor()
        {
            Assert.AreNotEqual(_objController.GetAgendaFrom(new User() { Id = 2 }).Count, 0);
        }

        [TestMethod]
        public void ShouldNotHaveAnyAgendaFromMissingDoctor()
        {
            Assert.AreEqual(_objController.GetAgendaFrom(new User() { Id = 150 }).Count, 0);
        }
    }
}
