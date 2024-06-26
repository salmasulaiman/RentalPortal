using Microsoft.AspNetCore.Mvc;

namespace RentalPortal.Controllers
{
    public class OwnerHome : Controller
    {
        public IActionResult OwnerProfile_Pageload()
        {
            return View();
        }
    }
}
