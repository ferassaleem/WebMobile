using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMobile.Data;
using WebMobile.Data.Base;
using WebMobile.Models;

namespace WebMobile.Data.Services
{
    public class CompanyService : EntityBaseRepository<Company>, ICompanyServices
    {
        public CompanyService(AppDbContext context) : base(context) { }

    }
}