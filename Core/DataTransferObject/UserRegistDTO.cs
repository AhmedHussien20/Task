using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObject
{
    public class UserRegistDTO
    {
      
        public string FullNameArabic { get; set; }

        public string FullNameEnglish { get; set; }
        
        [Required(ErrorMessage = "Mobile number is required")]
        [MinLength(10, ErrorMessage = "Mobile number should be min of 10 length")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile number should be in numbers")]
        public string MobileNo { get; set; }
        
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
        public string DeviceToken { get; set; }
 
        [MaxLength(4,ErrorMessage = "Country code should not exceed by length 4")]
        public string CountryKey { get; set; }

        public string ImgUrl { get; set; }

    }
}
