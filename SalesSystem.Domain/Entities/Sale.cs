using System.Collections.Generic;
using System.Linq;
using SalesSystem.Common.Resources;
using SalesSystem.Common.Validation;

namespace SalesSystem.Domain.Entities
{
    public class Sale : EntityBase
    {
        #region Ctor

        protected Sale() { }

        public Sale(string orderNumber, int customerId)
        {
            SetOrderNumber(orderNumber);
            SetCustomer(customerId);
            SaleProducts = new List<SaleProduct>();
            SetIsActive(true);
        }

        #endregion

        #region Properties

        public const int OrderNumberMaxLength = 16;

        public string OrderNumber { get; private set; }
        public int CustomerId { get; private set; }

        public virtual Customer Customer { get; private set; }
        public virtual ICollection<SaleProduct> SaleProducts { get; private set; }

        public virtual decimal TotalSale => SaleProducts.Sum(sp => sp.TotalPrice);

        #endregion

        #region Methods

        public void SetCustomer(int customerId)
        {
            AssertionConcern.AssertArgumentNotNull(customerId, Errors.CustomerRequired);
            CustomerId = customerId;
        }

        public void SetOrderNumber(string orderNumber)
        {
            AssertionConcern.AssertArgumentLength(orderNumber??"", OrderNumberMaxLength, string.Format(Errors.OrderNumberMaxLength, OrderNumberMaxLength));
            OrderNumber = orderNumber??"";
        }

        public void AddSaleProduct(SaleProduct saleProduct)
        {
            SaleProducts.Add(saleProduct);
        }

        public void RemoveSaleProduct(SaleProduct saleProduct)
        {
            SaleProducts.Remove(saleProduct);
        }

        public bool IsValid()
        {
            return SaleProducts.Any();
        }

        #endregion
    }
}
