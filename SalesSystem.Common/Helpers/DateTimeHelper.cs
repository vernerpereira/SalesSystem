using System;

namespace SalesSystem.Common.Helpers
{
    public static class DateTimeHelper
    {
        public static int GetAge(this DateTime bornDate)
        {
            var today = DateTime.Today;
            var age = today.Year - bornDate.Year;
            if (bornDate > today.AddYears(-age)) age--;
            return age;
        }
    }
}
