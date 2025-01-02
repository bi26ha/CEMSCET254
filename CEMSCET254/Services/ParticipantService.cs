using CEMSCET254.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CEMSCET254.Services
{
    public class ParticipantService
    {
        private readonly CEMSContext _context;

        public ParticipantService(CEMSContext context)
        {
            _context = context;
        }

        public async Task<List<Participant>> GetAllParticipantsAsync()
        {
            return await _context.Participants.ToListAsync();
        }

        public async Task<Participant> GetParticipantByIdAsync(int id)
        {
            return await _context.Participants.FindAsync(id);
        }

        public async Task AddParticipantAsync(Participant newParticipant)
        {
            _context.Participants.Add(newParticipant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateParticipantAsync(Participant updatedParticipant)
        {
            _context.Participants.Update(updatedParticipant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteParticipantAsync(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant != null)
            {
                _context.Participants.Remove(participant);
                await _context.SaveChangesAsync();
            }
        }
    }
}

