using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebMobile.Data;
using WebMobile.Data.Services;
using WebMobile.Models;

namespace WebMobile.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCompany = await _service.GetAllAsync();
            return View(allCompany);
        }


        //Get: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CompanyPictureURL,CompanyName")] Company company)
        {
            if (!ModelState.IsValid) return View(company);
            await _service.AddAsync(company);
            return RedirectToAction(nameof(Index));
        }

        //Get: Companies/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);
            if (companyDetails == null) return View("NotFound");
            return View(companyDetails);
        }

        //Get: Companies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);
            if (companyDetails == null) return View("NotFound");
            return View(companyDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyPictureURL,CompanyName")] Company company)
        {
            if (!ModelState.IsValid) return View(company);
            await _service.UpdateAsync(id, company);
            return RedirectToAction(nameof(Index));
        }

        //Get: Companies/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);
            if (companyDetails == null) return View("NotFound");
            return View(companyDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);
            if (companyDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
