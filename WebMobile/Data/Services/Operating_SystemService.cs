using WebMobile.Data.Base;
using WebMobile.Models;

namespace WebMobile.Data.Services
{
    public class Operating_SystemService : EntityBaseRepository<Operating_System>, IOperating_SystemService
    {
        public Operating_SystemService(AppDbContext context) : base(context) { }
    }
}
