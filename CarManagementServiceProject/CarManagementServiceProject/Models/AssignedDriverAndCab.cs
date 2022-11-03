using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarManagementServiceProject.Models
{
    public class AssignedDriverAndCab
    {
        [Key]
        public int RaidKey { get; set; }

       
        [Column(TypeName = "int")]
        [Required(ErrorMessage ="Enter the value")]
       // [System.ComponentModel.DefaultValue("1")]//no use
        public int RideId { get; set; }

        [Column(TypeName = "bit")]
        public bool IsAssigned { get; set; }

        //[Column(TypeName ="bit")]
        /*public bool OwnedStatus { get; set; }*/

        // 1 => Owned  0 => Not


        [ForeignKey("Cab")]
        public int CabId { get; set; }
        public Cab Cab  { get ; set; }

        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        public Driver Driver  { get; set; }
    }
}

