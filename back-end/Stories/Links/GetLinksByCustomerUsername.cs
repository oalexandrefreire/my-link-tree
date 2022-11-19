using Data.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Stories.Links
{
    public class GetLinksByCustomerUsername
    {
        private LinksContext _context;
        public GetLinksByCustomerUsername(LinksContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Link>> ExecuteAsync(string usuario)
        {
            return await this._context.Links
                .Include(x => x.Customer)
                .Where(x => x.Customer.Username == usuario)
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.Position)
                .ToListAsync();
        }
    }
}
