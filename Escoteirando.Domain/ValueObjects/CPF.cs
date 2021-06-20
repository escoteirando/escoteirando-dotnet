using System;
using System.Linq;

namespace Escoteirando.Domain.ValueObjects
{
    public class CPF
    {
        private readonly string _cpf;

        public CPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException(nameof(cpf));
            cpf = JustNumbers(cpf);
            if (!IsValidCPF(cpf))
            {
                throw new ArgumentException("Invalid CPF", nameof(cpf));
            }

            _cpf = cpf;
        }

        public static string JustNumbers(string text)
        {
            return string.Join("", text
                .Select(c => c)
                .Where(c => c is >= '0' and <= '9')
                .ToArray());
        }
        public static bool IsValidCPF(string cpf)
        {
            var multiplicador1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            var multiplicador2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};

            cpf = JustNumbers(cpf);

            if (cpf.Length != 11)
                return false;

            var tempCpf = cpf[..9];
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            var digito = resto.ToString();

            tempCpf += digito;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;


            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }


        public override string ToString() => _cpf;
    }
}