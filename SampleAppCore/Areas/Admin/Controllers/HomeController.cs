using Microsoft.AspNetCore.Mvc;
using SampleAppCore.Extensions;

namespace SampleAppCore.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var email = User.GetSpecificClaim("Email");
            return View();
        }
    }
}