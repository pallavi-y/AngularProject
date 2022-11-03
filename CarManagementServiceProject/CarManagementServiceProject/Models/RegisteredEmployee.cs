using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace CarManagementServiceProject.Models
{
    public class RegisteredEmployee
    {

        [Key]
        public int Key { get; set; }
        [Required(ErrorMessage = "Employee Id is Missing")]
        public string EmployeeId { get; set; }
        [Required(ErrorMessage = "Enter the email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage ="Enter the password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       

        [Required(ErrorMessage ="Enter the number")]
        [DataType(DataType.PhoneNumber)]
        public long EmployeePhoneNumber { get; set; }

        [Required(ErrorMessage="Enter the Address")]
        [DataType(DataType.MultilineText)]
        public string EmployeeAddress { get; set; }


        [Required(ErrorMessage = "LandMark is Missing")]
        public string LandMark { get; set; }

        [Column(TypeName = "bit")]
        [System.ComponentModel.DefaultValue("False")]
        public bool PickUpStatus { get; set; }

        [System.ComponentModel.DefaultValue("False")]
        [Column(TypeName = "bit")]
        public bool DropStatus { get; set; }
    }
}
