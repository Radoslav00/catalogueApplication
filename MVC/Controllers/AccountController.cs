using ApplicationService.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using MVC.ViewModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            try
            {
                if (this.Request.IsAuthenticated)
                {
                    if (ReturnUrl==null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return this.RedirectToLocal(ReturnUrl);
                }
            }
            catch 
            {

                throw;
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginVM loginVM, string ReturnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var UserData = new PersonDTO
                    {
                       Username = loginVM.Email,
                       Password = loginVM.Password
                    };
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        if (service.Authorize(UserData))
                        {
                            SignInUser(UserData.Username, false);
                            if (ReturnUrl==null || ReturnUrl.Equals("/Account/LogOff"))
                                return RedirectToAction("Index", "Home");
                            return RedirectToLocal(ReturnUrl);
                        }
                    }


                }
            }
            catch 
            {

                throw;
            }
            return RedirectToAction("Index", "Person");
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            IOwinContext ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register(string ReturnPage)
        {
            try
            {
                //verify
                if (this.Request.IsAuthenticated)
                {
                    //return view
                    return this.RedirectToLocal(ReturnPage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterVM registerVM, string ReturnPage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {

                        var person = new PersonDTO
                        {
                            Username = registerVM.Email,
                            Password = registerVM.Password,
                            PositionID = 1
                        };
                        if (service.SetPerson(person).Length<27)
                        {
                            ModelState.AddModelError("", "Unable to register");
                        }
                        else
                        {
                            this.SignInUser(person.Username, false);
                            return this.RedirectToLocal(ReturnPage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return View(registerVM);
        }

        public ActionResult RedirectToLocal (string LocalUrl)
        {
            try
            {
                if (Url.IsLocalUrl(LocalUrl))
                {
                    return Redirect(LocalUrl);
                }
            }
            catch 
            {

                throw;
            }
            return RedirectToAction("LogOff", "Account");
        }
        private void SignInUser(string Data, bool isPersistent)
        {
            var claims = new List<Claim>();

            try
            {
                //setting
                claims.Add(new Claim(ClaimTypes.Name, Data));
                claims.Add(new Claim(ClaimTypes.Email, Data));
                var claimIdentities = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdentities);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Authorize]
        public ActionResult Details()
        {
            return View();
        }
    }
}