using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAppManagerContent.Helpers;
using WebAppManagerContent.Models;

namespace WebAppManagerContent.Controllers
{
    public class AccountController : Controller
    {
        string url = $"https://localhost:44334/api/user";
        ConsumeRESTfulAPI consumeRESTfulAPI = new ConsumeRESTfulAPI();

        // GET: PruebaController
        public ActionResult Index()
        {
            string url = $"https://localhost:44334/api/user";
            string jsonResult = consumeRESTfulAPI.GetItems(url);
            List<AccountModel> model = JsonConvert.DeserializeObject<List<AccountModel>>(jsonResult);
            return View(model);
        }

        // GET: PruebaController/Details/5
        public ActionResult Login(LoginModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            string jsonResult = consumeRESTfulAPI.PostItem(url, data);
            return RedirectToAction("Index");
            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        return RedirectToLocal(returnUrl);
            //    case SignInStatus.LockedOut:
            //        return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            //    case SignInStatus.Failure:
            //    default:
            //        ModelState.AddModelError("", "Invalid login attempt.");
            //        return View(model);
            //}

        }

        // GET: PruebaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PruebaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var list = new Dictionary<string, string>();
                    model.Password = Extensions.Base64Encode(model.SPassword);
                    string data = JsonConvert.SerializeObject(model);
                    string jsonResult = consumeRESTfulAPI.PostItem(url, data);
                    return RedirectToAction("Index");
                }
                catch (WebException ex)
                {
                    return View();
                }
            }
            return View(model);
        }

        // GET: PruebaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PruebaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AccountModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PruebaController/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: PruebaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



    }
}
