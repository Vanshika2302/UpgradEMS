using Microsoft.EntityFrameworkCore;
using UpGradEMS.DAL.Models;

namespace UpGradEMS.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventDetails> Events { get; set; }
        public DbSet<UserInfo> Users { get; set; }

        public DbSet<SpeakerDetails> Speakers { get; set; }
        public DbSet<SessionInfo> Sessions { get; set; }
        public DbSet<ParticipantEventDetails> ParticipantEvents { get; set; }
    }
}