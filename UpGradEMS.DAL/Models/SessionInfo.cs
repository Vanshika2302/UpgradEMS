using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpGradEMS.DAL.Models
{
    public class SessionInfo
    {
        [Key]
        public Guid SessionId { get; set; }

        [Required]
        public Guid EventId { get; set; }  

        [Required]
        [StringLength(50)]
        public string SessionTitle { get; set; } = "";

        public Guid SpeakerId { get; set; }   

        public string? Description { get; set; }

        [Required]
        public DateTime SessionStart { get; set; }

        [Required]
        public DateTime SessionEnd { get; set; }

        public string? SessionUrl { get; set; }
        public EventDetails? Event { get; set; }
        public SpeakerDetails? Speaker { get; set; }
    }
}