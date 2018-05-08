namespace SalesSystem.Common.Helpers
{
    public static class PaginatorHelper
    {
        public static int CalculateOffset(int page, int items, int totalRows)
        {
            if (page > 0)
                page = page - 1;

            return page > 0 ? page * items : 0;
        }
    }
}
