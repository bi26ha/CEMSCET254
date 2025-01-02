using CEMSCET254.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CEMSCET254.Services
{
    public class VenueService
    {
        private readonly CEMSContext _context;

        public VenueService(CEMSContext context)
        {
            _context = context;
        }

        public async Task<List<Venue>> GetAllVenuesAsync()
        {
            return await _context.Venues.ToListAsync();
        }

        public async Task<Venue> GetVenueByIdAsync(int id)
        {
            return await _context.Venues.FindAsync(id);
        }

        public async Task AddVenueAsync(Venue newVenue)
        {
            _context.Venues.Add(newVenue);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVenueAsync(Venue updatedVenue)
        {
            _context.Venues.Update(updatedVenue);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVenueAsync(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue != null)
            {
                _context.Venues.Remove(venue);
                await _context.SaveChangesAsync();
            }
        }
    }
}
