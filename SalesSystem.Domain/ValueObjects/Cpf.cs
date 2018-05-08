using System;
using SalesSystem.Common.Helpers;
using SalesSystem.Common.Resources;

namespace SalesSystem.Domain.ValueObjects
{
    public class Cpf
    {
        #region Ctor

        protected Cpf()
        {

        }

        public Cpf(string cpf)
        {
            try
            {
                cpf = CpfClean(cpf);
                if (!IsValid(cpf))
                    throw new Exception(Errors.InvalidCpf);

                Code = Convert.ToInt64(cpf);
            }
            catch (Exception)
            {
                throw new Exception(Errors.InvalidCpf + ": " + cpf);
            }
        }

        #endregion

        #region Properties

        public long Code { get; private set; }

        #endregion

        #region Methods

        public string GetWithoutZeros()
        {
            return Code.ToString();
        }

        public static string CpfClean(string cpf)
        {
            cpf = StringHelper.GetNumbers(cpf);

            if (string.IsNullOrEmpty(cpf))
                return "";

            while (cpf.StartsWith("0"))
                cpf = cpf.Substring(1);

            return cpf;
        }
        
        public string GetFullCpf()
        {
            var cpf = Code.ToString();

            if (string.IsNullOrEmpty(cpf))
                return "";

            while (cpf.Length < 11)
                cpf = "0" + cpf;

            return cpf;
        }

        public string GetFormated()
        {
            return Convert.ToInt64(GetFullCpf()).ToString(@"000\.000\.000\-00");
        }

        public static bool IsValid(string cpf)
        {
            while (cpf.Length < 11)
                cpf = "0" + cpf;

            var product1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var product2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            var tempCpf = cpf.Substring(0, 9);
            var sum = 0;

            for (var i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * product1[i];
            var rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            var digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (var i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * product2[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest;
            return cpf.EndsWith(digit);
        }

        #endregion
    }
}
