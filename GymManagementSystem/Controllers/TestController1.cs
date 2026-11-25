using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class TestController1 : Controller
    {
        public IActionResult Index()
        {
            int data = 10;
            return View(data);
        }
    }
}
