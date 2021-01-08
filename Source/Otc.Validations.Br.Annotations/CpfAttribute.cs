using Otc.ComponentModel.DataAnnotations;

namespace Otc.Validations.Br.Annotations
{
    public class CpfAttribute : ValidationAttribute
    {
        public bool IsRequired { get; set; } = true;

        public override bool IsValid(object value)
        {
            var cpf = value?.ToString();

            if (string.IsNullOrEmpty(cpf) && !IsRequired)
            {
                return true;
            }

            return CpfValidation.IsValid(cpf);
        }
    }
}
