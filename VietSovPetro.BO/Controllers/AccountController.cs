using System.Web.Mvc;
using System.Web.Security;

namespace VietSovPetro.BO.Controllers
{
    using System;

    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string status)
        {
            ViewBag.Status = status;

            if (Session["VietSovPetroAdmin"] != null)
            {
                return RedirectToAction("Index", "Article");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection f)
        {
            if (Session["VietSovPetroAdmin"] != null)
            {
                return RedirectToAction("Index", "Article");
            }
            string username = f["UserName"];
            string password = f["Password"];
            bool remember = f["Remember"] != null;
            if (username == "admin" && password == "admin")
            {
                FormsAuthentication.SetAuthCookie(username, remember);
                Session["VietSovPetroAdmin"] = username;
                return RedirectToAction("Index", "Article");
            }
            return RedirectToAction("Login", new { status = "Tài khoản hoặc mật khẩu không đúng!" });
        }
        //Troy
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["VietSovPetroAdmin"] = null;
            return RedirectToAction("Login");
        }
    }
}
