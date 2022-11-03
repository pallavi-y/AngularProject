using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarManagementServiceProject.Models
{
    public class Cab
    {
        [Key]

        public int CabId { get; set; }

        [Column(TypeName = "varchar(12)")]
        [Required(ErrorMessage = "Cab Name is missing")]
        public string CabNumber { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "Cab Name is missing")]
        public string CabName { get; set; }

        [Column(TypeName = "tinyint")]
        [Required(ErrorMessage = "No. of Seats is missing")]
        public int No_of_Seats { get; set; }

        [Column(TypeName = "bit")]
        [Required(ErrorMessage = "Engine type is missing")]
        public bool Engine_Type { get; set; }

        // 0 => Petrol 1 => Diesel

        [Column(TypeName = "bit")]
        [Required(ErrorMessage = "Fuelled state is missing")]
        public bool Fuelled { get; set; }

        // 0 => Yes 1 => No

        [Column(TypeName = "bit")]
        [Required(ErrorMessage = "VehicleStatus is missing")]
        public bool Vehicle_Status { get; set; }

       

        // 0 => Active 1 => Inactive


    }
}
