using Microsoft.AspNetCore.Mvc;
using SampleAppCore.Extensions;

namespace SampleAppCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var email = User.GetSpecificClaim("Email");
            return View();
        }
    }
}