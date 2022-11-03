using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagementServiceProject.Models
{
    public class EmployeePickUpDetails
    {
        [Key]
        public int PickUpID { get; set; }

        [ForeignKey("registeredEmployee")]
        public int EmployeeId { get; set; }
        public  RegisteredEmployee  registeredEmployee { get; set; }


        [ForeignKey("assignedDriverAndCab")]
        public int RideId { get; set; }
        public  AssignedDriverAndCab assignedDriverAndCab { get; set; }


        [Column(TypeName = "Time")]
      //  [System.ComponentModel.DefaultValue("")]
        public TimeSpan ExpectedPickUp { get; set; }

        [Column(TypeName = "Time")]

        public TimeSpan ActualPickUp { get; set; }



    }
}
