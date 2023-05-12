using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMobile.Data;
using WebMobile.Data.Base;
using WebMobile.Models;

namespace WebMobile.Data.Services
{
    public class OperatingSystemService : EntityBaseRepository<Operating_System>, IOperatingSystemService
    {
        public OperatingSystemService(AppDbContext context) : base(context) { }
    }
}
