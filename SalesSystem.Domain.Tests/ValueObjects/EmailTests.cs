using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem.Domain.ValueObjects;

namespace SalesSystem.Domain.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Email_Empty()
        {
            var email = new Email("");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Email_Null()
        {
            var email = new Email(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Email_MaxLength()
        {
            var address = "verner.pereira@gmail.com".PadLeft(Email.AddressMaxLength, 'a');
            var email = new Email("a"+address);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_Invalid_01()
        {
            var email = new Email("asdf");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_Invalid_02()
        {
            var email = new Email("asdf@");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_Invalid_03()
        {
            var email = new Email("asdf@as");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_Invalid_04()
        {
            var email = new Email("@asdf");
        }

        [TestMethod]
        public void Email_Valid()
        {
            var email = new Email("verner@gmail.com");
            Assert.AreEqual("verner@gmail.com", email.Address);
        }
    }
}
