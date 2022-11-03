using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagementServiceProject.Models
{
    public class EmployeeDropDetails
    {

        [Key]
        public int DropID { get; set; }

        [ForeignKey("registeredEmployee")]
        public int EmployeeId { get; set; }
        public  RegisteredEmployee registeredEmployee { get; set; }


        [ForeignKey("assignedDriverAndCab")]
        public int RaidId { get; set; }
        public  AssignedDriverAndCab assignedDriverAndCab { get; set; }



        [Column(TypeName = "Time")]

        public TimeSpan ActualDrop { get; set; }

    }
}
