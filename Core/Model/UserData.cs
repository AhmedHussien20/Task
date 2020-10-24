using Model.Helper;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class UserData : BaseEntity
    {
        public UserData()
        {

        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]

        public override long ID { get; set; }

        [MaxLength(Shared.DefaultStringLength)]
        public string UserName { get; set; }

        [MaxLength(Shared.DefaultStringLength)]

        public string UserPassword { get; set; }

        [MaxLength(Shared.DefaultStringLength)]

        public string FullNameArabic { get; set; }

        [MaxLength(Shared.DefaultStringLength)]

        public string FullNameEnglish { get; set; }
         
        [NotMapped]
        public string Password
        {
            get
            {
                return UserPassword.Decrypt();
            }
            set
            {
                value = UserPassword.Encrypt();
            }
        }
        [MaxLength(30)]
        public string MobileNo { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(Shared.DefaultStringLength)]
        public string DeviceToken { get; set; }

        [MaxLength(5)]
        public string CountryKey { get; set; }

        [MaxLength(Shared.DefaultStringLength)]
        public string ImgUrl { get; set; }

        [NotMapped]
        public long? CurrentConnectedContactId { get; set; }

        [NotMapped]
        public long? CurrentConnectedRoomId { get; set; }
    }
}
