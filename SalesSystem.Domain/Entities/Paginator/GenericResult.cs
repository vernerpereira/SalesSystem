using System.Collections.Generic;
using SalesSystem.Common.Resources;
using SalesSystem.Common.Validation;

namespace SalesSystem.Domain.Entities.Paginator
{
    public class GenericResult<TEntity> where TEntity : class
    {
        public List<TEntity> Entities { get; private set; }
        public int Page { get; private set; }
        public int RowsPerPage { get; private set; }
        public int TotalRows { get; private set; }

        public GenericResult(List<TEntity> entities, int page, int rowsPerPage, int totalRows)
        {
            SetPage(page);
            SetRowsPerPage(rowsPerPage);
            SetTotalRows(totalRows);
            Entities = entities;
        }
        
        public void SetPage(int page)
        {
            AssertionConcern.AssertArgumentNotNull(page, Errors.PageRequired);
            Page = page < 1 ? 1 : page;
        }

        public void SetRowsPerPage(int rowsPerPage)
        {
            AssertionConcern.AssertArgumentNotNull(rowsPerPage, Errors.RowsPerPageRequired);
            RowsPerPage = rowsPerPage;
        }

        public void SetTotalRows(int totalRows)
        {
            AssertionConcern.AssertArgumentNotNull(totalRows, Errors.TotalRowsRequired);
            TotalRows = totalRows;
        }
    }
}
