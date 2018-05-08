using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem.Domain.Entities;

namespace SalesSystem.Domain.Tests.Entities
{
    [TestClass]
    public class SaleProductTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SaleProduct_Quantity_Zero()
        {
            var saleProduct = new SaleProduct(1, 0, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SaleProduct_UnitPrice_Zero()
        {
            var saleProduct = new SaleProduct(1, 2, 0);
        }

        [TestMethod]
        public void SaleProduct_TotalPrice()
        {
            var saleProduct = new SaleProduct(1, 2, (decimal)10.25);
            Assert.AreEqual((decimal)20.50, saleProduct.TotalPrice);
        }
    }
}
