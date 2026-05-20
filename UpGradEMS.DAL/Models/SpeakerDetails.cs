using System;
using System.ComponentModel.DataAnnotations;

namespace UpGradEMS.DAL.Models
{
    public class SpeakerDetails
    {
        [Key]
        public Guid SpeakerId { get; set; }

        [Required]
        [StringLength(50)]
        public string SpeakerName { get; set; } = "";
    }
}