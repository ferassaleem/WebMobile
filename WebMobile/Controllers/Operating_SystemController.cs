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
    public class Operating_SystemController : Controller
    {
        private readonly IOperating_SystemService _service;

        public Operating_SystemController(IOperating_SystemService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allOperating = await _service.GetAllAsync();
            return View(allOperating);
        }


        //Get: Operatings/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("OperatingPictureURL,OperatingName")] Operating_System Operating)
        {
            if (!ModelState.IsValid) return View(Operating);

            await _service.AddAsync(Operating);
            return RedirectToAction(nameof(Index));
        }

        //Get: Operatings/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var OperatingDetails = await _service.GetByIdAsync(id);
            if (OperatingDetails == null) return View("NotFound");
            return View(OperatingDetails);
        }

        //Get: Operatings/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var OperatingDetails = await _service.GetByIdAsync(id);
            if (OperatingDetails == null) return View("NotFound");
            return View(OperatingDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, OperatingPictureURL,OperatingName")] Operating_System Operating)
        {
            if (!ModelState.IsValid) return View(Operating);
            if(id ==  Operating.Id)
            {
                await _service.UpdateAsync(id, Operating);
                return RedirectToAction(nameof(Index));
            }
            return View(Operating);
        }

        //Get: Operatings/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var OperatingDetails = await _service.GetByIdAsync(id);
            if (OperatingDetails == null) return View("NotFound");
            return View(OperatingDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var OperatingDetails = await _service.GetByIdAsync(id);
            if (OperatingDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
