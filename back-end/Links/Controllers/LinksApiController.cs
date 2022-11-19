using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SpreadArray;
using Stories.Customers;
using Stories.Links;
using System.Dynamic;

namespace Links.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksApiController : ControllerBase
    {
        private readonly GetLinksByCustomerUsername getLinksByCustomerUsername;
        private readonly GetCustomer getCustomer;
        private readonly CustomerExists customerExists;

        public LinksApiController(LinksContext context)
        {
            this.getLinksByCustomerUsername = new GetLinksByCustomerUsername(context);
            this.customerExists = new CustomerExists(context);
            this.getCustomer = new GetCustomer(context);
        }

        [HttpGet("{username?}")]
        public async Task<IActionResult> IndexAsync(string username = "alexandrefreire")
        {
            if (!this.customerExists.Execute(username))
                return null;

            var links = await this.getLinksByCustomerUsername.ExecuteAsync(username);
            var customer = await this.getCustomer.ExecuteAsync(username);
            dynamic result = new ExpandoObject();
            result.customer = customer;
            result.links = links;
            return Ok(result);
        }
    }
}
