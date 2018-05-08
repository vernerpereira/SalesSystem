using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem.Domain.ValueObjects;

namespace SalesSystem.Domain.Tests.ValueObjects
{
    [TestClass]
    public class CpfTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Cpf_Empty()
        {
            var cpf = new Cpf("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Cpf_Null()
        {
            var cpf = new Cpf(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Cpf_Invalid()
        {
            var cpf = new Cpf("123.123.123-12");
        }

        [TestMethod]
        public void Cpf_Valid()
        {
            var cpf = new Cpf("818.958.063-99");
            Assert.AreEqual(81895806399, cpf.Code);
        }

        [TestMethod]
        public void Cpf_Formated()
        {
            var cpf = new Cpf("81895806399");
            Assert.AreEqual("818.958.063-99", cpf.GetFormated());
        }
    }
}
