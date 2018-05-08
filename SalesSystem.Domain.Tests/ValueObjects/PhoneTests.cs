using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem.Domain.ValueObjects;

namespace SalesSystem.Domain.Tests.ValueObjects
{
    [TestClass]
    public class PhoneTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Phone_Ddd_Empty()
        {
            var phone = new Phone("", "1234-1234");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Phone_Ddd_Null()
        {
            var phone = new Phone(null, "1234-1234");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Phone_Ddd_MaxLength()
        {
            var phone = new Phone("".PadRight(Phone.DddMaxLength, '0') + "0", "1234-1234");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Phone_Number_Empty()
        {
            var phone = new Phone("35", "");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Phone_Number_Null()
        {
            var phone = new Phone("35", null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Phone_Number_MaxLength()
        {
            var phone = new Phone("35", "".PadRight(Phone.NumberMaxLength, '0') + "0");
        }

        [TestMethod]
        public void Phone_FullNumber()
        {
            var phone = new Phone("35", "1234-1234");
            Assert.AreEqual("(35) 1234-1234", phone.GetFullPhone());
        }
    }
}
