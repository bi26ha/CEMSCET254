using CEMSCET254.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CEMSCET254.Services
{
    internal class RegistrationService
    {
        private readonly CEMSContext _context;

        public RegistrationService(CEMSContext context)
        {
            _context = context;
        }

        // Get all registrations for an event
        public async Task<List<Registration>> GetRegistrationsByEventAsync(int eventId)
        {
            return await _context.Registrations
                .Where(r => r.EventId == eventId)
                .Include(r => r.Participant)
                .ToListAsync();
        }

        // Register a participant for an event
        public async Task RegisterParticipantAsync(int eventId, int participantId)
        {
            var registration = new Registration
            {
                EventId = eventId,
                ParticipantId = participantId,
                RegistrationDate = DateTime.Now,
                Status = "Registered"
            };

            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();
        }

        // Get registration by ID
        public async Task<Registration> GetRegistrationByIdAsync(int registrationId)
        {
            return await _context.Registrations
                .Include(r => r.Event)
                .Include(r => r.Participant)
                .FirstOrDefaultAsync(r => r.Id == registrationId);
        }

        // Update registration status (e.g., canceling registration)
        public async Task UpdateRegistrationAsync(Registration registration)
        {
            _context.Registrations.Update(registration);
            await _context.SaveChangesAsync();
        }

        // Delete a registration
        public async Task DeleteRegistrationAsync(int registrationId)
        {
            var registration = await _context.Registrations.FindAsync(registrationId);
            if (registration != null)
            {
                _context.Registrations.Remove(registration);
                await _context.SaveChangesAsync();
            }
        }
    }
}