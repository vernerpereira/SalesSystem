using System.Collections.Generic;
using SalesSystem.Common.Resources;
using SalesSystem.Common.Validation;

namespace SalesSystem.Domain.Entities
{
    public class Product : EntityBase
    {
        #region Ctor

        protected Product() { }

        public Product(string name, decimal price)
        {
            SetName(name);
            SetPrice(price);
            SetIsActive(true);
        }

        #endregion

        #region Properties

        public const int NameMaxLength = 100;
        public const decimal PriceMaxValue = (decimal) 999999999.99;

        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public virtual ICollection<SaleProduct> SaleProducts { get; private set; }

        #endregion

        #region Methods

        public void SetName(string name)
        {
            AssertionConcern.AssertArgumentNotEmpty(name, Errors.NameRequired);
            AssertionConcern.AssertArgumentLength(name, NameMaxLength, string.Format(Errors.NameMaxLength, NameMaxLength));

            Name = name;
        }

        public void SetPrice(decimal price)
        {
            AssertionConcern.AssertArgumentNotNull(price, Errors.UnitPriceRequired);
            AssertionConcern.AssertArgumentRange(price, 0, PriceMaxValue, string.Format(Errors.UnitPriceRange, 0, PriceMaxValue));

            Price = price;
        }

        #endregion
    }
}
