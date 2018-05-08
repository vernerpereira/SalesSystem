using SalesSystem.Common.Resources;
using SalesSystem.Common.Validation;

namespace SalesSystem.Domain.ValueObjects
{
    public class Email
    {
        #region Ctor

        protected Email()
        {

        }

        public Email(string address)
        {
            AssertionConcern.AssertArgumentNotEmpty(address, Errors.EmailAddressRequired);
            AssertionConcern.AssertArgumentLength(address, AddressMaxLength, string.Format(Errors.EmailAddressMaxLength, AddressMaxLength));
            EmailAssertionConcern.AssertIsValid(address);

            Address = address;
        }

        #endregion

        #region Properties

        public const int AddressMaxLength = 254;
        public string Address { get; private set; }

        #endregion
    }
}
