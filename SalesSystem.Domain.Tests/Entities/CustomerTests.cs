using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.ValueObjects;

namespace SalesSystem.Domain.Tests.Entities
{
    [TestClass]
    public class CustomerTests
    {
        private string _name;
        private DateTime _bornDate;
        private Phone _phone;
        private Cpf _cpf;
        private Email _email;

        public CustomerTests()
        {
            _name = "Verner Estevam Pereira";
            _bornDate = new DateTime(1984, 12, 29);
            _phone = new Phone("35", "1234-1234");
            _cpf = new Cpf("695.514.486-34");
            _email = new Email("vernerpereira@gmail.com");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Customer_Name_Empty()
        {
            var customer = new Customer("", _bornDate, _phone, _cpf, _email);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Customer_Name_Null()
        {
            var customer = new Customer(null, _bornDate, _phone, _cpf, _email);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Customer_Name_MaxLength()
        {
            var customer = new Customer(_name.PadRight(Customer.NameMaxLength) + "a", _bornDate, _phone, _cpf, _email);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Customer_Phone_Null()
        {
            var customer = new Customer(_name, _bornDate, null, _cpf, _email);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Customer_Cpf_Null()
        {
            var customer = new Customer(_name, _bornDate, _phone, null, _email);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Customer_Email_Null()
        {
            var customer = new Customer(_name, _bornDate, _phone, _cpf, null);
        }
        
        [TestMethod]
        public void Customer_Age()
        {
            var days = DateTime.Now.Subtract(new DateTime(2018, 04, 08)).TotalDays;
            var bornDate = _bornDate.AddDays(days);
            var customer = new Customer(_name, bornDate, _phone, _cpf, _email);
            Assert.AreEqual(33, customer.Age);
        }
    }
}
