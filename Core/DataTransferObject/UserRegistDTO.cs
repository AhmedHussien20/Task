using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObject
{
    public class UserRegistDTO
    {
      
        

        public string UserName { get; set; }
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Mobile number is required")]
        [MinLength(10, ErrorMessage = "Mobile number should be min of 10 length")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile number should be in numbers")]
        public string MobileNo { get; set; }
        
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
