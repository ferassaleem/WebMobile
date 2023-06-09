﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebMobile.Data;
using WebMobile.Data.Services;
using WebMobile.Data.ViewModels;
using WebMobile.Models;


namespace WebMobile.Controllers
{
    public class MobileController : Controller
    {
        private readonly IMobileService _service;

        public MobileController(IMobileService service)
        {
            _service = service;
        }
        //GET: Mobiles/Create
        public async Task<IActionResult> Create()
        {
            var MobileDropdownsData = await _service.GetNewMobileDropdownsValues();

            ViewBag.Companies = new SelectList(MobileDropdownsData.Companies, "Id", "CompanyName");
            ViewBag.Operatings = new SelectList(MobileDropdownsData.Operatings, "Id", "OperatingName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Mobile mobile)
        {
            if (!ModelState.IsValid)
            {
                var mobileDropdownsData = await _service.GetNewMobileDropdownsValues();

                ViewBag.Companies = new SelectList(mobileDropdownsData.Companies, "Id", "CompanyName");
                ViewBag.Operatings = new SelectList(mobileDropdownsData.Operatings, "Id", "OperatingName");

                return View(mobile);
            }

            await _service.AddNewMobileAsync(mobile);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMobile = await _service.GetAllAsync(n => n.Company, m => m.Operating);
            
            return View(allMobile);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMobile = await _service.GetAllAsync(n => n.Company, n => n.Operating);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allMobile.Where(n => string.Equals(n.MobileName, searchString, StringComparison.CurrentCultureIgnoreCase)||
                    (string.Equals(n.Processor, searchString, StringComparison.CurrentCultureIgnoreCase))||
                    (string.Equals(n.RAM, searchString, StringComparison.CurrentCultureIgnoreCase)) ||
                    (string.Equals(n.Camera, searchString, StringComparison.CurrentCultureIgnoreCase)) ||
                    (string.Equals(n.Screen, searchString, StringComparison.CurrentCultureIgnoreCase)) ||
                    (string.Equals(n.Battery, searchString, StringComparison.CurrentCultureIgnoreCase)) ||
                    (string.Equals(Convert.ToString(n.Price), searchString, StringComparison.CurrentCultureIgnoreCase)) ||
                    (string.Equals(n.Company.CompanyName, searchString, StringComparison.CurrentCultureIgnoreCase)) ||
                    (string.Equals(n.Operating.OperatingName, searchString, StringComparison.CurrentCultureIgnoreCase))).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMobile);
        }

        //GET: Mobiles/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var MobileDetail = await _service.GetMobileByIdAsync(id);
            return View(MobileDetail);
        }




        //GET: Mobiles/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var mobileDetails = await _service.GetMobileByIdAsync(id);
            if (mobileDetails == null) return View("NotFound");

            var response = new Mobile()
            {
                Id = mobileDetails.Id,
                MobilePictureURL = mobileDetails.MobilePictureURL,
                MobileName = mobileDetails.MobileName,
                Processor = mobileDetails.Processor,
                RAM = mobileDetails.RAM,
                Camera = mobileDetails.Camera,
                Screen = mobileDetails.Screen,
                Battery = mobileDetails.Battery,
                Price = mobileDetails.Price,

                OperatingId = mobileDetails.OperatingId,
                CompanyId = mobileDetails.CompanyId,
            };

            var mobileDropdownsData = await _service.GetNewMobileDropdownsValues();
            ViewBag.Companies = new SelectList(mobileDropdownsData.Companies, "Id", "CompanyName");
            ViewBag.Operatings = new SelectList(mobileDropdownsData.Operatings, "Id", "OperatingName");


            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Mobile mobile)
        {
            if (id != mobile.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var mobileDropdownsData = await _service.GetNewMobileDropdownsValues();

                ViewBag.Companies = new SelectList(mobileDropdownsData.Companies, "Id", "CompanyName");
                ViewBag.Operatings = new SelectList(mobileDropdownsData.Operatings, "Id", "OperatingName");


                return View(mobile);
            }

            await _service.UpdateMobileAsync(mobile);
            return RedirectToAction(nameof(Index));

        }
        //Get: Mobile/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var mobileDetails = await _service.GetByIdAsync(id);
            if (mobileDetails == null) return View("NotFound");
            return View(mobileDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var mobileDetails = await _service.GetByIdAsync(id);
            if (mobileDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

