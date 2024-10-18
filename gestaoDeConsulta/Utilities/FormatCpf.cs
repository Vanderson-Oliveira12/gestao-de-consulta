using System.Text.RegularExpressions;

namespace gestaoDeConsulta.Utilities
{
    public static class FormatCpf
    {
        // Método para formatar o CPF removendo pontos e hífen
        public static string CleanCpf(string cpf)
        {
            if ( string.IsNullOrWhiteSpace(cpf) )
                return cpf;

            // Remove pontos e hífen
            return Regex.Replace(cpf, @"[.\-]", "");
        }

        // Método para validar o CPF após formatação
        public static bool IsValidCpf(string cpf)
        {
            // Limpa o CPF antes de validar
            cpf = CleanCpf(cpf);

            if ( string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 )
                return false;

            // Verifica se todos os dígitos são iguais (caso inválido)
            if ( cpf.All(c => c == cpf[0]) )
                return false;

            // Calcula os dígitos verificadores
            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for ( int i = 0 ; i < 9 ; i++ )
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;

            soma = 0;
            for ( int i = 0 ; i < 10 ; i++ )
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
