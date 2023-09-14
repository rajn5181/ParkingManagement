using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckStatus.Model
{
    public class CPA
    {
        [Key]
        public string Pid { get; set; }

        [Required]
        public bool Status { get; set; }

        public List<SlotModel> Slots { get; set; } // Corrected property name 'Slot' to 'Slots'

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Available { get; set; } // Changed property type to DateTime
    }
}
