using System.Text.RegularExpressions;

namespace MFA.Domain.Extensions
{
    public static partial class StringExtensions
    {

        [GeneratedRegex(@"[^\d]")]
        private static partial Regex RegexNumbers();


        public static bool ValidateCPF(this string cpf)
        {
            cpf = cpf.OnlyNumbers();

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int[] pesosDigito1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesosDigito2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma1 = 0;
            for (int i = 0; i < 9; i++)
            {
                soma1 += int.Parse(cpf[i].ToString()) * pesosDigito1[i];
            }
            int resto1 = soma1 % 11;
            int digitoVerificador1 = (resto1 < 2) ? 0 : (11 - resto1);

            int soma2 = 0;
            for (int i = 0; i < 10; i++)
            {
                soma2 += int.Parse(cpf[i].ToString()) * pesosDigito2[i];
            }
            int resto2 = soma2 % 11;
            int digitoVerificador2 = (resto2 < 2) ? 0 : (11 - resto2);

            return (digitoVerificador1 == int.Parse(cpf[9].ToString()) && digitoVerificador2 == int.Parse(cpf[10].ToString()));
        }

        public static bool ValidateCNPJ(this string cnpj)
        {
            cnpj = cnpj.OnlyNumbers();

            if (cnpj.Length != 14)
                return false;

            if (cnpj.Distinct().Count() == 1)
                return false;

            int[] pesosDigito1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesosDigito2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma1 = 0;
            for (int i = 0; i < 12; i++)
            {
                soma1 += int.Parse(cnpj[i].ToString()) * pesosDigito1[i];
            }
            int resto1 = soma1 % 11;
            int digitoVerificador1 = (resto1 < 2) ? 0 : (11 - resto1);

            int soma2 = 0;
            for (int i = 0; i < 13; i++)
            {
                soma2 += int.Parse(cnpj[i].ToString()) * pesosDigito2[i];
            }
            int resto2 = soma2 % 11;
            int digitoVerificador2 = (resto2 < 2) ? 0 : (11 - resto2);
            return (digitoVerificador1 == int.Parse(cnpj[12].ToString()) && digitoVerificador2 == int.Parse(cnpj[13].ToString()));
        }

        public static bool ValidateEmail(this string email)
        {
            if (email.Contains("@gmail.com")) return true;
            if (email.Contains("@hotmail.com")) return true;
            if (email.Contains("@outlook.com")) return true;

            return false;
        }

        public static string OnlyNumbers(this string strNumber)
        {
            return RegexNumbers().Replace(strNumber, "");
        }
    }
}