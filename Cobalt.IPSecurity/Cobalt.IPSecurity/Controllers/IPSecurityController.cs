using Microsoft.AspNetCore.Mvc;

namespace Cobalt.IPSecurity.Controllers
{
    public class IPSecurityController : Controller
    {
        [Route("cp/ip-security")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
