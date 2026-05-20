using UpGradEMS.DAL.Data;
using UpGradEMS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace UpGradEMS.DAL.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<EventDetails> GetAll()
        {
            return _context.Events.ToList();
        }

        public void Add(EventDetails eventObj)
        {
            if (eventObj == null) return;  

            _context.Events.Add(eventObj);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var ev = _context.Events.FirstOrDefault(e => e.EventId == id); 

            if (ev != null)
            {
                _context.Events.Remove(ev);
                _context.SaveChanges();
            }
        }
    }
}