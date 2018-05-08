using System;
using System.Configuration;
using System.Web;
using SalesSystem.Common.Resources;

namespace SalesSystem.MVC.Helpers
{
    public static class PaginationHelper
    {
        public static string MakePagination(int currentPage, int totalRows, int rowsPerPage, string controller, string action)
        {
            var pageCount = (int) Math.Ceiling(((decimal) totalRows / (decimal) rowsPerPage));
            currentPage--;
            // variable of pagination links
            var counter = "<div class='dataTables_paginate paging_simple_numbers block' id='datatable_paginate' align='center'>";

            // delimiter to make before and after current page
            const int delimiter = 3;

            // left limit
            var leftLimit = 0;

            //right limit
            var rightLimit = (currentPage + delimiter);

            // Begin left math
            if (currentPage > delimiter)
                leftLimit = (currentPage - delimiter);

            // Begin right math
            if ((currentPage + delimiter) >= pageCount)
                rightLimit = pageCount;

            var more = HttpContext.Current.Request.Url.Query;

            if (pageCount > 1)
            {
                counter += "<ul class='pagination'>";

                if (currentPage > 0)
                {
                    counter += "<li class='paginate_button'><a href=" + ConfigurationManager.AppSettings["BaseUrl"].ToString() + "/" + controller + "/" + action + "/" + 1 + more + "> << </a></li>" +
                               "<li class='paginate_button'><a href=" + ConfigurationManager.AppSettings["BaseUrl"].ToString() + "/" + controller + "/" + action + "/" + ((currentPage + 1) - 1) + more + ">" + Fields.Previous + "</a><li>";
                }

                // first part making
                for (var i = leftLimit; i <= rightLimit; i++)
                {
                    if (i == pageCount)
                        break;
                    if (i == currentPage)
                        counter += "<li class='paginate_button active'><a href=" + ConfigurationManager.AppSettings["BaseUrl"].ToString() + "/" + controller + "/" + action + "/" + (i + 1) + more + ">  " + (i + 1) + " </a></li>";
                    else
                        counter += "<li class='paginate_button'><a href=" + ConfigurationManager.AppSettings["BaseUrl"].ToString() + "/" + controller + "/" + action + "/" + (i + 1) + more + ">  " + (i + 1) + " </a></li>";
                }

                if (currentPage < (pageCount - 1))
                {
                    counter += "<li class='paginate_button'><a href=" + ConfigurationManager.AppSettings["BaseUrl"].ToString() + "/" + controller + "/" + action + "/" + (currentPage + 2) + more + ">" + Fields.Next + "</a></li>" +
                               "<li class='paginate_button'><a href=" + ConfigurationManager.AppSettings["BaseUrl"].ToString() + "/" + controller + "/" + action + "/" + pageCount + "/" + more + "> >> </a></li>";
                }

                counter += "</ul>";
            }
            counter += "</div>";

            return counter;
        }
    }
}