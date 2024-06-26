using Microsoft.AspNetCore.Mvc;
using RentalPortal.Models;

namespace RentalPortal.Controllers
{
    public class LoginController : Controller
    {
        RentalDB dbobj = new RentalDB();
        public IActionResult Login_Load()
        {
            return View();
        }
        public IActionResult Login_Click(Login objcls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = dbobj.LoginDB(objcls);
                    if (resp == "Owner")
                    {
                        int id = Convert.ToInt32(dbobj.LoginIdDB(objcls));
                        TempData["uid"] = id;
                        
                        ////TempData["msg"] = resp;
                        return RedirectToAction("OwnerProfile_Pageload", "OwnerHome");
                    }
                    else if(resp == "Buyer")
                    {
                        int id = Convert.ToInt32(dbobj.LoginIdDB(objcls));
                        TempData["uid"] = id;
                        //TempData["msg"] = resp;
                        return RedirectToAction("BuyerProfile_Pageload", "BuyerHome");
                    }
                    else
                    {
                        TempData["msg"] = resp;
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("Login_Load", objcls);
        }
    }
}
