using Microsoft.AspNetCore.Mvc;

namespace Cobalt.Forums.Controllers
{
    public class ForumController : Controller
    {
        [Route("forums")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
