using SalesSystem.Common.Resources;
using SalesSystem.Common.Validation;

namespace SalesSystem.Domain.Entities
{
    public class SaleProduct : EntityBase
    {
        #region Ctor

        protected SaleProduct() { }

        public SaleProduct(int productId, int quantity, decimal unitPrice)
        {
            SetProduct(productId);
            SetQuantity(quantity);
            SetUnitPrice(unitPrice);
            SetIsActive(true);
        }

        #endregion

        #region Properties

        public const decimal UnitPriceMaxValue = (decimal)999999999.99;

        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }

        public virtual decimal TotalPrice => Quantity * UnitPrice;

        #endregion

        #region Methods

        public void SetUnitPrice(decimal unitPrice)
        {
            AssertionConcern.AssertArgumentNotNull(unitPrice, Errors.NameRequired);
            AssertionConcern.AssertArgumentRange(unitPrice, (decimal)0.01, UnitPriceMaxValue, string.Format(Errors.UnitPriceRange, (decimal)0.01, UnitPriceMaxValue));
            UnitPrice = unitPrice;
        }

        public void SetQuantity(int quantity)
        {
            AssertionConcern.AssertArgumentNotNull(quantity, Errors.QuantityRequired);
            AssertionConcern.AssertArgumentRange(quantity, 1, int.MaxValue, string.Format(Errors.QuantityRange, 1, int.MaxValue));
            Quantity = quantity;
        }

        public void SetProduct(int productId)
        {
            AssertionConcern.AssertArgumentNotNull(productId, Errors.ProductRequired);
            ProductId = productId;
        }

        #endregion
        
    }
}
