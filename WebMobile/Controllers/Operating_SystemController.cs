using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebMobile.Data;

namespace WebMobile.Controllers
{
    public class Operating_SystemController : Controller
    {
        private readonly AppDbContext _context;
        public Operating_SystemController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var alloperating = await _context.Operatings.ToListAsync();

            return View(alloperating);
        }
    }
}
