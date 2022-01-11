using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Validations
{
    public class ProductCreateDto {
        public string EmailAddress { get; set; }
    }
    public class ProductCreateValidator : IValidator<ProductCreateDto>
    {
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        public void Validate(ProductCreateDto dto)
        {
            if (!dto.EmailAddress.Contains("@"))
            {
                ValidationResult.AddError(new ValidationErrorResult { Key = "Email", ValidationMessage = "E-Posta formatında kayıt giriniz" });
            }
        }

        public ProductCreateValidator()
        {
            var v = new ProductCreateValidator();
            v.Validate(new ProductCreateDto { EmailAddress = "Ali" });


            if (v.ValidationResult.IsValid)
            {
                // işlem Valid
            }
        }
    }

    public class ValidationErrorResult
    {
        /// <summary>
        /// // Hangi propertyde alanda hata olduğu bilgisi için
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// // Hata Mesajı için
        /// </summary>
        public string ValidationMessage { get; set; } 
    }

    public class ValidationResult
    {
        public bool IsValid { get; private set; } = true;

        /// <summary>
        /// Nesne içerisinde birden fazla hata olma ihtimaline göre eklendi.
        /// </summary>
        public List<ValidationErrorResult> Errors { get; private set; }

        public void AddError(ValidationErrorResult error)
        {
            IsValid = false; // tek bir hata bile varsa bu nesne valid doğrulanamaz.
            Errors.Add(error);
        }
    }

    public interface IValidator<TDto> where TDto:class
    {
       
        /// <summary>
        /// Validate işlemi sonrası nesnenin valid olup olmadığı varsa hata mesajlarını yakalamak için yaptık
        /// </summary>
        ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Frontend tarafında gönderilen dtonun validasyon kurallarına uyup uymadığını kontrol ederiz.
        /// </summary>
        /// <param name="dto"></param>
        void Validate(TDto dto);
    }
}
