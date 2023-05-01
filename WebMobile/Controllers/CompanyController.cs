using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebMobile.Data;
using WebMobile.Models;
using WebMobile.Services;

namespace WebMobile.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyServices _service;
        public CompanyController(ICompanyServices service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allcompany = await _service.GetAll();
            return View(allcompany);
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CompanyName, CompanyPictureURL")] Company company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }
            await _service.AddAsync(company);
            return RedirectToAction(nameof(Index));
        }

        //Details
        public async Task<IActionResult> Details(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);

            if (companyDetails == null) return View("Empty");
            return View(companyDetails);
        }
    }
}
