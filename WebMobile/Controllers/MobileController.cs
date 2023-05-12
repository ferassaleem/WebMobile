using Microsoft.AspNetCore.Authorization;
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
            ViewBag.Operatings = new SelectList(MobileDropdownsData.Operatings, "Id", "Operating_SystemName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMobile mobile)
        {
            if (!ModelState.IsValid)
            {
                var mobileDropdownsData = await _service.GetNewMobileDropdownsValues();

                ViewBag.Companies = new SelectList(mobileDropdownsData.Companies, "Id", "CompanyName");
                ViewBag.Operatings = new SelectList(mobileDropdownsData.Operatings, "Id", "Operating_SystemName");

                return View(mobile);
            }

            await _service.AddNewMobileAsync(mobile);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMobile = await _service.GetAllAsync(n => n.Company);
            return View(allMobile);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMobile = await _service.GetAllAsync(n => n.Company);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allMobile.Where(n => string.Equals(n.MobileName, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(n.Processor, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(n.RAM, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                    string.Equals(n.Camera, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                    string.Equals(n.Screen, searchString, StringComparison.CurrentCultureIgnoreCase) ||
                    string.Equals(n.Battery, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

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

            var response = new NewMobile()
            {
                Id = mobileDetails.Id,
                MobilePictureURL = mobileDetails.MobilePictureURL,
                MobileName = mobileDetails.MobileName,
                Processor = mobileDetails.Processor,
                RAM = mobileDetails.RAM,
                Camera = mobileDetails.Camera,
                Screen = mobileDetails.Screen,
                Battery = mobileDetails.Battery,
                OperatingSystemId = mobileDetails.OperatingSystemId,
                CompanyId = mobileDetails.CompanyId,
            };

            var mobileDropdownsData = await _service.GetNewMobileDropdownsValues();
            ViewBag.Companies = new SelectList(mobileDropdownsData.Companies, "Id", "CompanyName");
            ViewBag.Operatings = new SelectList(mobileDropdownsData.Operatings, "Id", "Operating_SystemName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMobile mobile)
        {
            if (id != mobile.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var mobileDropdownsData = await _service.GetNewMobileDropdownsValues();

                ViewBag.Companies = new SelectList(mobileDropdownsData.Companies, "Id", "CompanyName");
                ViewBag.Operatings = new SelectList(mobileDropdownsData.Operatings, "Id", "Operating_SystemName");

                return View(mobile);
            }

            await _service.UpdateMobileAsync(mobile);
            return RedirectToAction(nameof(Index));

        }





    }
}

