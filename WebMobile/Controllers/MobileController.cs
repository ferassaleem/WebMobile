using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebMobile.Data;

namespace WebMobile.Controllers
{
    public class MobileController : Controller
    {
        private readonly AppDbContext _context;
        public MobileController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allmobiles = await _context.Mobiles.Include(n => n.OperatingSystem).Include(m => m.Company).ToListAsync();

            return View(allmobiles);
        }
         
    }
}
