using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Instructormanager.Models
{
    public class Instructor
    {
       
        [Key]
        public long Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DataType(DataType.Text)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "OtherName")]
        public string Othername { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Column(TypeName = "nvarchar(11)")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Home Address")]
        [Column(TypeName = "nvarchar(1000)")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Year of Experience")]
        public int YearOfExp { get; set; }
    }
}
