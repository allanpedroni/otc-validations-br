using Otc.ComponentModel.DataAnnotations;

namespace Otc.Validations.Br.Annotations
{
    public class CnpjAttribute : ValidationAttribute
    {
        public bool IsRequired { get; set; } = true;

        public override bool IsValid(object value)
        {
            var cnpj = value?.ToString();

            if (string.IsNullOrEmpty(cnpj) && !IsRequired)
            {
                return true;
            }

            return CnpjValidation.IsValid(cnpj);
        }
    }
}