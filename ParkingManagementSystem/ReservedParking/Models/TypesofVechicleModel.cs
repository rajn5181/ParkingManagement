using System.ComponentModel.DataAnnotations;

namespace ReservedParking.Models
{
    public class TypesofVechicleModel
    {
        [Key]
        public int Tid { get; set; }
        public string Categories { set; get; }
    }
}
