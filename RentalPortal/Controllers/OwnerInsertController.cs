using Microsoft.AspNetCore.Mvc;
using RentalPortal.Models;

namespace RentalPortal.Controllers
{
    public class OwnerInsertController : Controller
    {
        RentalDB dbobj=new RentalDB();
        public IActionResult OwnerInsert_Load()
        {
            return View();
        }
        public IActionResult OwnerInsert_Click(OwnerInsert objcls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = dbobj.OwnerInsertDB(objcls);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("OwnerInsert_Load", objcls);

        }
    }
}
