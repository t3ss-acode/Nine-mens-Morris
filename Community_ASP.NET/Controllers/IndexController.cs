﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Community_ASP.NET.Data;
using Community_ASP.NET.Models;
using Community_ASP.NET.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Community_ASP.NET.Controllers
{
    [Authorize]
    public class IndexController : Controller
    {   
        private readonly UserManager<Community_ASPNETUser> _userManager;

        public IndexController(UserManager<Community_ASPNETUser> userManager)
        {
            _userManager = userManager;
        }
        

        // GET: IndexController
        
        public ActionResult Index()
        {
            try
            {
                var userInfoList = new List<UserInfo>();

                var user = UserBL.GetUser(_userManager.GetUserId(User));
                userInfoList.Add(user);

                return View(userInfoList);
            }
            catch (Exception e)
            {
                TempData["sErrMsg"] = e.Message;
                return View();
                //return Redirect("~/");
            }
            
        }
        
        public PartialViewResult ShowError(string sErrorMessage)
        {
            return PartialView("ErrorMessageView");
        }

        // GET: IndexController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndexController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndexController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: IndexController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndexController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: IndexController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndexController/Delete/5
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
