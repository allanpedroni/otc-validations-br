using AnnotationsSampleApp;
using Otc.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;


static bool IsValid<T>(T model)
{
    var validationContext = new ValidationContext(model);
    var validationResults = new List<ValidationResult>();
    return Validator.TryValidateObject(model, validationContext, validationResults, true);
}

var requiredIsValid = IsValid(new Model { Cpf = "000.000.000-00" });

Console.WriteLine("{0,-12}:{1,6}", "Cpf válido", requiredIsValid);

var optionalIsValid = IsValid(new Model {Cpf = "410.850.372-40", CpfOptional = null });

Console.WriteLine("{0,-12}:{1,6}", "Cpf válido", optionalIsValid);

var cnpjRequiredIsValid = IsValid(new CnpjModel { Cnpj = "00.000.000/0000-00" });

Console.WriteLine("{0,-12}:{1,6}", "Cnpj válido", cnpjRequiredIsValid);

var cnpjRequiredIsOptional = IsValid(new CnpjModel { Cnpj = "32.971.074/0001-61", CnpjOptional = null });

Console.WriteLine("{0,-12}:{1,6}", "Cnpj válido", cnpjRequiredIsOptional);


