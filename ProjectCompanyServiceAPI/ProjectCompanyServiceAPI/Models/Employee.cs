using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProjectCompanyServiceAPI.Models
{
    public class Employee
    {
     
        [Key]
        public int EmpId { get; set; }
        [AllowNull]
        public string PUID { get; set; }


        [Required(ErrorMessage = "Enter the Employee  Name")]
        [StringLength(20)]
        public string EmployeeName { get; set; }


        [Required(ErrorMessage = "Enter the password")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Required(ErrorMessage = "Enter the EmailId")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter the Phone Number")]
        [DataType(DataType.PhoneNumber)]


        public long phonenumber { get; set; }

        [Required(ErrorMessage = "Enter the Address")]
        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }


        [Required(ErrorMessage = "Enter the landmark")]
        [StringLength(30)]
        public string LandMark { get; set; }
    }
}

