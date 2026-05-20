using System;
using System.ComponentModel.DataAnnotations;

namespace UpGradEMS.DAL.Models
{
    public class ParticipantEventDetails
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string ParticipantEmailId { get; set; } = "";

        [Required]
        public Guid EventId { get; set; }

        public bool IsAttended { get; set; } = false;

        public EventDetails? Event { get; set; }
    }
}