using SalesSystem.Common.Resources;
using SalesSystem.Common.Validation;

namespace SalesSystem.Domain.ValueObjects
{
    public class Phone
    {
        #region Ctor

        protected Phone()
        {

        }

        public Phone(string ddd, string number)
        {
            SetNumber(number);
            SetDdd(ddd);
        }

        #endregion

        #region Properties

        public const int NumberMaxLength = 10;
        public string Number { get; private set; }

        public const int DddMaxLength = 3;
        public string Ddd { get; private set; }

        #endregion

        #region Methods

        public void SetNumber(string number)
        {
            AssertionConcern.AssertArgumentNotEmpty(number, Errors.PhoneNumberRequired);
            AssertionConcern.AssertArgumentLength(number, NumberMaxLength, string.Format(Errors.NumberMaxLength, NumberMaxLength));

            Number = number;
        }

        public void SetDdd(string ddd)
        {
            AssertionConcern.AssertArgumentNotEmpty(ddd, Errors.DddNumberRequired);
            AssertionConcern.AssertArgumentLength(ddd, DddMaxLength, string.Format(Errors.DddMaxLength, DddMaxLength));

            Ddd = ddd;
        }

        public string GetFullPhone()
        {
            return $"({Ddd}) {Number}";
        }

        #endregion
    }
}
