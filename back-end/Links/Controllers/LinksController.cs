using Data.Data;
using Links.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Stories.Customers;
using Stories.Links;
using System.Diagnostics;

namespace Links.Controllers
{
    public class LinksController : Controller
    {
        private readonly GetLinksByCustomerUsername getLinksByCustomerUsername;
        private readonly GetCustomer getCustomer;
        private readonly CustomerExists customerExists;

        public LinksController(LinksContext context)
        {
            this.getLinksByCustomerUsername = new GetLinksByCustomerUsername(context);
            this.customerExists = new CustomerExists(context);
            this.getCustomer = new GetCustomer(context);
        }

        [HttpGet("{username?}")]
        public async Task<IActionResult> IndexAsync(string username = "alexandrefreire")
        {
            if (!this.customerExists.Execute(username))
                return NotFound();

            var links = await this.getLinksByCustomerUsername.ExecuteAsync(username);
            var customer = await this.getCustomer.ExecuteAsync(username);
            ViewData["Links"] = links;
            ViewData["Customer"] = customer;
            return View("Link");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}