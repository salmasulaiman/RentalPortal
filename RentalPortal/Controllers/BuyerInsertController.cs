using Microsoft.AspNetCore.Mvc;
using RentalPortal.Models;

namespace RentalPortal.Controllers
{
    public class BuyerInsertController : Controller
    {

        RentalDB dbobj = new RentalDB();
        public IActionResult BuyerInsert_Load()
        {
            return View();
        }
        public IActionResult BuyerInsert_Click(BuyerInsert objcls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = dbobj.BuyerInsertDB(objcls);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("BuyerInsert_Load", objcls);

        }
    }
}
