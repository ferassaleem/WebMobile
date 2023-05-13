using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMobile.Data;
using WebMobile.Data.Base;
using WebMobile.Models;

namespace WebMobile.Data.Services
{
    public class OperatingService : EntityBaseRepository<Operating>, IOperatingService
    {
        public OperatingService(AppDbContext context) : base(context) { }

    }
}