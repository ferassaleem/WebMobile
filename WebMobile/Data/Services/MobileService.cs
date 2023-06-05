using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebMobile.Data.Base;
using WebMobile.Data.ViewModels;
using WebMobile.Models;

namespace WebMobile.Data.Services
{
    public class MobilesService : EntityBaseRepository<Mobile>, IMobileService
    {
        private readonly AppDbContext _context;
        public MobilesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMobileAsync(Mobile data)
        {
            var newMobile = new Mobile()
            {
                MobilePictureURL = data.MobilePictureURL,
                MobileName = data.MobileName,
                Processor = data.Processor,
                RAM = data.RAM,
                Camera = data.Camera,
                Screen = data.Screen,
                Battery = data.Battery,
                Price = data.Price,
                OperatingId = data.OperatingId,
                CompanyId = data.CompanyId
            };
            await _context.Mobiles.AddAsync(newMobile);
            await _context.SaveChangesAsync();
        }

        public async Task<Mobile> GetMobileByIdAsync(int id)
        {
            var MobileDetails = await _context.Mobiles
                .Include(c => c.Company)
                .Include(p => p.Operating)
                .FirstOrDefaultAsync(n => n.Id == id);

            return MobileDetails;
        }

        public async Task<NewMobileDropdowns> GetNewMobileDropdownsValues()
        {
            var response = new NewMobileDropdowns()
            {
                Companies = await _context.Companies.OrderBy(n => n.CompanyName).ToListAsync(),
                Operatings = await _context.Operatings.OrderBy(n => n.OperatingName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMobileAsync(Mobile data)
        {
            var dbMobile = await _context.Mobiles.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMobile != null)
            {
                dbMobile.MobilePictureURL = data.MobilePictureURL;
                dbMobile.MobileName = data.MobileName;
                dbMobile.Processor = data.Processor;
                dbMobile.RAM = data.RAM;
                dbMobile.Camera = data.Camera;
                dbMobile.Screen = data.Screen;
                dbMobile.Battery = data.Battery;
                dbMobile.Price = data.Price;
                dbMobile.OperatingId = data.OperatingId;
                dbMobile.CompanyId = data.CompanyId;
                await _context.SaveChangesAsync();
            }
        }
    }

}
