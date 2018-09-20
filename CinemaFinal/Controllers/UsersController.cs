using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CinemaFinal.Models;

namespace CinemaFinal.Controllers
{
    public class UsersController : Controller
    {
        private CinemaFinalDBContext db = new CinemaFinalDBContext();
        // private UserManager userManager = new UserManager();

        // GET: User
        public ActionResult Index()
        {
            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return View();
        }

        // GET: Useres/Details/5
        public ActionResult Details(int? id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Users/Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                if (db.Users.Any(u => u.UserName == user.UserName))
                {
                    ModelState.AddModelError("key1", "Username already exists");
                    return View();
                }

                user.Password = Utils.GenerateHash(user.Password);
                db.Users.Add(user);
                db.SaveChanges();

                FormsAuthentication.RedirectFromLoginPage("Regular", false);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: User/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Users/Login
        [HttpPost]
        public ActionResult Login(User user, bool rememberMe)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                string password = Utils.GenerateHash(user.Password);
                User foundUser = db.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == password);

                if (foundUser != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(foundUser.IsAdmin ? "Admin" : "Regular", rememberMe);
                    Session["User"] = foundUser;
                    if (foundUser.IsAdmin == false)
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        return RedirectToAction("AdminAction", "Home");

                    }
                }
                else
                {
                    ModelState.AddModelError("key1", "Incorrect username or password");
                    return View();
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

    }
}



