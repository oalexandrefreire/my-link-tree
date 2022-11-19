using Data.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Stories.Customers
{
    public class GetCustomer
    {
        private LinksContext _context;
        public GetCustomer(LinksContext _context)
        {
            this._context = _context;
        }

        public async Task<Customer> ExecuteAsync(string username)
        {
            var customer = await _context.Customers
                .Include(x=> x.Template)
                .Where(x => x.Username == username)
                .FirstAsync();
            return customer;
        }
    }
}
