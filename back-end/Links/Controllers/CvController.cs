using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Stories.Customers;
using Stories.Cv;

namespace Links.Controllers
{
    public class CvController : Controller
    {
        private GetCustomer getCustomer;
        private GetCareerProfile getCareerProfile;
        private CustomerExists customerExists;

        public CvController(LinksContext context)
        {
            this.customerExists = new CustomerExists(context);
            this.getCustomer = new GetCustomer(context);
            this.getCareerProfile = new GetCareerProfile(context);
        }

        [HttpGet("Cv/{username?}")]
        public async Task<IActionResult> IndexAsync(string username = "alexandrefreire")
        {
            if (!this.customerExists.Execute(username))
                return NotFound();

            var customer = await this.getCustomer.ExecuteAsync(username);
            var careerProfile = await this.getCareerProfile.ExecuteAsync(username);
            ViewData["Customer"] = customer;
            ViewData["CareerProfile"] = careerProfile;

            string lang = HttpContext.Request.Query["lang"].ToString();
            if (!String.IsNullOrEmpty(lang))
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Append("googtrans", $"/{customer.DefaultLang}/{lang}", option);
            }
            //else Response.Cookies.Delete("googtrans");
            return View();
        }

        
        public IActionResult Pdf()
        {
            return View();
        }
    }
}
