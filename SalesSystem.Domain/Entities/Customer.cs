using System;
using System.Collections.Generic;
using SalesSystem.Common.Resources;
using SalesSystem.Common.Validation;
using SalesSystem.Common.Helpers;
using SalesSystem.Domain.ValueObjects;

namespace SalesSystem.Domain.Entities
{
    public class Customer : EntityBase
    {
        #region Ctor

        protected Customer() { }

        public Customer(string name, DateTime bornDate, Phone phone, Cpf cpf, Email email)
        {
            SetName(name);
            SetBornDate(bornDate);
            SetPhone(phone);
            SetCpf(cpf);
            SetEmail(email);
            SetIsActive(true);
            Sales = new List<Sale>();
        }

        #endregion

        #region Properties

        public const int NameMaxLength = 100;

        public string Name { get; private set; }
        public DateTime BornDate { get; private set; }
        public Phone Phone { get; private set; }
        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }

        public virtual ICollection<Sale> Sales { get; private set; }
        public virtual int Age => BornDate.GetAge();
            
        #endregion

        #region Methods

        public void SetName(string name)
        {
            AssertionConcern.AssertArgumentNotEmpty(name, Errors.NameRequired);
            AssertionConcern.AssertArgumentLength(name, NameMaxLength, string.Format(Errors.NameMaxLength, NameMaxLength));

            Name = name;
        }

        public void SetBornDate(DateTime bornDate)
        {
            AssertionConcern.AssertArgumentNotNull(bornDate, Errors.BornDateRequired);

            BornDate = bornDate;
        }

        public void SetPhone(Phone phone)
        {
            AssertionConcern.AssertArgumentNotNull(phone, Errors.PhoneRequired);

            Phone = phone;
        }

        public void SetCpf(Cpf cpf)
        {
            AssertionConcern.AssertArgumentNotNull(cpf, Errors.CpfRequired);

            Cpf = cpf;
        }

        public void SetEmail(Email email)
        {
            AssertionConcern.AssertArgumentNotNull(email, Errors.EmailRequired);

            Email = email;
        }

        #endregion
        
    }
}
