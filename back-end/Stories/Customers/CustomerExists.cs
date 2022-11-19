using Data.Data;

namespace Stories.Customers
{
    public class CustomerExists
    {
        private LinksContext _context;
        public CustomerExists(LinksContext _context)
        {
            this._context = _context;
        }

        public bool Execute(string username)
        {
            return this._context.Customers.Any(e => e.Username == username);
        }
    }
}
