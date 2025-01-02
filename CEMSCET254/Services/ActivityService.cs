using CEMSCET254.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CEMSCET254.Services
{
    public class ActivityService
    {
        private readonly CEMSContext _context;

        public ActivityService(CEMSContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> GetAllActivitiesAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public async Task AddActivityAsync(Activity newActivity)
        {
            _context.Activities.Add(newActivity);
            await _context.SaveChangesAsync(); // 🟩 **Fixed SaveChangesAsync() usage**
        }

        public async Task UpdateActivityAsync(Activity updatedActivity)
        {
            _context.Activities.Update(updatedActivity);
            await _context.SaveChangesAsync(); // 🟩 **Fixed SaveChangesAsync() usage**
        }

        public async Task DeleteActivityAsync(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync(); // 🟩 **Fixed SaveChangesAsync() usage**
            }
        }
    }
}
