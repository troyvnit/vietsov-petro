using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EFMVCPycoNet.Core.Common;

namespace EFMVCPycoNet.Domain.Entities
{
    public class User
    {
        public User()
        {
            CreateOn = DateTime.Now;
        }

        [Key]
        public int UserID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
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
