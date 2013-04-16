using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VietSovPetro.Core.Common;

namespace VietSovPetro.Model.Entities
{
    public class User
    {
        public User()
        {
            CreateOn = DateTime.Now;
        }

        [Key]
        public Guid UserID { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public string PasswordHashed { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? LastLoginOn { get; set; }
        public string Password
        {
            set { PasswordHashed = Encryption.MD5EncryptPassword(value); }
        }
        public string DisplayName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
