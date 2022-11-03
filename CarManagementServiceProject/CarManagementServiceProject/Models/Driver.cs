using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarManagementServiceProject.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        [Required(ErrorMessage = "Driver Name is missing")]
        public string DriverName { get; set; }

        [Column(TypeName = "Bigint")]
        [Required(ErrorMessage = "Drive Phone number is missing")]
        public long PhoneNumber { get; set; }

        [Column(TypeName = "Bigint")]
        [Required(ErrorMessage = "Drive Alternative Phone number is missing")]
        public long Alt_PhoneNumber { get; set; }

        public string Location { get; set; }

        [Required(ErrorMessage = "Drive EmailAddress is missing")]
        [EmailAddressAttribute]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Drive Password is missing")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Drive Phone number is missing")]
        public int Age { get; set; }

       

        /*        [Column(TypeName = "bit")]
                [Required(ErrorMessage = "Car Owned status is missing")]
                public bool IsCarOwned { get; set; }*/




    }
}
