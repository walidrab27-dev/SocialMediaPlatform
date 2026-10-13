using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaPlatform.Data.Models
{
    public class User : BaseEntity
    {
        public int Id { get; private set; }
        private string _username;
        private string _email;
        private string _password;
        private string _bio;
        private DateTime _dateOfBirth;
        [Required]
        [MaxLength(100)]
        public string Username 
        { 
            get => this._username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("");
                this._username = value;
            }
        }
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email
        {
            get => this._email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("");
                this._email = value;
            }
        }
        [Required]
        [MinLength(8)]
        public string Password
        {
            get => this._password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("");
                this._password = value;
            }
        }
        [Required]
        [StringLength(500)]
        public string Bio
        {
            get => this._bio;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("");
                this._bio = value;
            }

        }
        [Required]
        public DateTime DateOfBirth
        {
            get => this._dateOfBirth;
            set
            {
                this._dateOfBirth = value;
            }
        }
        private User()
        {
            
        }
        public User(string username, string email, string password, string bio, DateTime dateOfBirth)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.Bio = bio;
            this.DateOfBirth = dateOfBirth;
        }
    }
}
