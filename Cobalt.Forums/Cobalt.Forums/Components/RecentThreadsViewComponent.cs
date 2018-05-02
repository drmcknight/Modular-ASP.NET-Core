using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cobalt.Forums.Components
{
    public class RecentThreadsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
