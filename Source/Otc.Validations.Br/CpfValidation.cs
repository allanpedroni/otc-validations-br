namespace Otc.Validations.Br
{
    public static class CpfValidation
    {
        // referencia: http://www.macoratti.net/11/09/c_val1.htm
        public static bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return false;
            }

            cpf = cpf.PadLeft(11, '0');
            var retorno = true;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                retorno = false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                if (int.TryParse(tempCpf[i].ToString(), out int valor))
                    soma += valor * multiplicador1[i];
                else
                    return false;
            }
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                if (int.TryParse(tempCpf[i].ToString(), out int valor))
                    soma += valor * multiplicador2[i];
                else
                    return false;
            }
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            if (!cpf.EndsWith(digito))
                retorno = false;

            string[] listaCpfsInvalidos = { "00000000000", "11111111111", "22222222222", "33333333333",
                                            "44444444444", "55555555555", "66666666666", "77777777777",
                                            "88888888888", "99999999999"};
            foreach (var cpfVerificado in listaCpfsInvalidos)
            {
                if (cpf.Equals(cpfVerificado))
                    return false;
            }

            return retorno;
        }
    }
}
