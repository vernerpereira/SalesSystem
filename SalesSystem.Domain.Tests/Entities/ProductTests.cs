using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem.Domain.Entities;

namespace SalesSystem.Domain.Tests.Entities
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Product_Name_Empty()
        {
            var product = new Product("", (decimal) 100.23);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Product_Name_Null()
        {
            var product = new Product(null, (decimal)100.23);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Product_Name_MaxLength()
        {
            var product = new Product("".PadRight(Product.NameMaxLength, 'a') + "a", (decimal)100.23);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Product_Price_MaxValue()
        {
            var product = new Product("iPhone", Product.PriceMaxValue + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Product_Price_MinValue()
        {
            var product = new Product("iPhone", -1);
        }
    }
}
