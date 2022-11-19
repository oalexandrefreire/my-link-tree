using Data.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Stories.Cv
{
    public class GetCareerProfile
    {
        private LinksContext _context;
        public GetCareerProfile(LinksContext _context)
        {
            this._context = _context;
        }

        public async Task<Profile> ExecuteAsync(string username)
        {
            var careerProfile = await _context.Profiles
                .Include(x=>x.Customer)
                .Include(x=>x.Contents.OrderByDescending(child => child.StartedAt))
                .ThenInclude(c => c.Section)
                .Where(x => x.Customer.Username == username)
                .FirstAsync();
            return careerProfile;
        }
    }
}
