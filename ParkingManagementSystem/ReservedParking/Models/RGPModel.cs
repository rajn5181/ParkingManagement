﻿using System.ComponentModel.DataAnnotations;

namespace ReservedParking.Models
{
    public class RGPModel
    {
        [Key]
        public string Rpid { get; set; }
        public string Email { get; set; }
        public string PKID { get; set; }
        public string PhoneNo { get; set; }
        public string Slot { get; set; }
        public string VehicleNo { get; set; }
        public string Identifications { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }


    }
}
