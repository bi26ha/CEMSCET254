using CEMSCET254.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CEMSCET254.Services
{
    public class EventService
    {
        private readonly CEMSContext _context;

        public EventService(CEMSContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events.Include(e => e.Activities).ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events.Include(e => e.Activities).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddEventAsync(Event newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            _context.Events.Update(updatedEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }

}

