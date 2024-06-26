using Microsoft.AspNetCore.Mvc;

namespace RentalPortal.Controllers
{
    public class BuyerHome : Controller
    {
        public IActionResult BuyerProfile_Pageload()
        {
            return View();
        }
    }
}
