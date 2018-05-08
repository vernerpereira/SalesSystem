using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem.Domain.Entities;

namespace SalesSystem.Domain.Tests.Entities
{
    [TestClass]
    public class SaleTests
    {
        private SaleProduct _saleProduct1;
        private SaleProduct _saleProduct2;

        public SaleTests()
        {
            _saleProduct1 = new SaleProduct(1, 2, (decimal) 100.50);
            _saleProduct2 = new SaleProduct(2,4, (decimal) 25.25);
        }

        [TestMethod]
        public void Sale_OrderNumber_Null()
        {
            var sale = new Sale(null, 1);
            Assert.AreNotEqual(null, sale);
        }

        [TestMethod]
        public void Sale_OrderNumber_Empty()
        {
            var sale = new Sale("", 1);
            Assert.AreNotEqual(null, sale);
        }

        [TestMethod]
        public void Sale_Valid()
        {
            var sale = new Sale("123", 1);
            sale.AddSaleProduct(_saleProduct1);
            Assert.AreEqual(true, sale.IsValid());
        }

        [TestMethod]
        public void Sale_Invalid()
        {
            var sale = new Sale("123", 1);
            Assert.AreEqual(false, sale.IsValid());
        }

        [TestMethod]
        public void Sale_TotalSale()
        {
            var sale = new Sale("123", 1);
            sale.AddSaleProduct(_saleProduct1);
            sale.AddSaleProduct(_saleProduct2);
            Assert.AreEqual(302, sale.TotalSale);
        }

        [TestMethod]
        public void Sale_RemoveProduct()
        {
            var sale = new Sale("123", 1);
            sale.AddSaleProduct(_saleProduct1);
            sale.AddSaleProduct(_saleProduct2);
            var before = sale.SaleProducts.Count;
            sale.RemoveSaleProduct(_saleProduct1);
            var afterRemove = sale.SaleProducts.Count;
            Assert.AreNotEqual(before, afterRemove);
        }
    }
}
