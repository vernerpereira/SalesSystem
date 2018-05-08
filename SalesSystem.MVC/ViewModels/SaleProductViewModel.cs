namespace SalesSystem.MVC.ViewModels
{
    public class SaleProductViewModel
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual ProductViewModel Product { get; set; }
        public virtual SaleViewModel Sale { get; set; }

        public virtual decimal TotalPrice => Quantity * UnitPrice;
    }
}