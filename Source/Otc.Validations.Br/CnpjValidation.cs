namespace Otc.Validations.Br
{
    public static class CnpjValidation
    {
        // referencia: http://www.macoratti.net/11/09/c_val1.htm
        public static bool IsValid(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();

            string[] listaCnpjsInvalidos = { "00000000000000", "11111111111111", "22222222222222", "33333333333333",
                                            "44444444444444", "55555555555555", "66666666666666", "77777777777777",
                                            "88888888888888", "99999999999999" };

            foreach (var cnpjVerificado in listaCnpjsInvalidos)
            {
                if (cnpj.Equals(cnpjVerificado))
                    return false;
            }

            return cnpj.EndsWith(digito);
        }
    }
}
