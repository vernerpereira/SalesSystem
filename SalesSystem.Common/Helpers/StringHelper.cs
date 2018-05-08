using System.Linq;

namespace SalesSystem.Common.Helpers
{
    public static class StringHelper
    {
        public static string GetNumbers(string text)
        {
            return string.IsNullOrEmpty(text) ? "" : new string(text.Where(char.IsDigit).ToArray());
        }
    }
}
