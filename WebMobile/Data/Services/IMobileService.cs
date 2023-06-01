using System.Threading.Tasks;
using WebMobile.Data.Base;
using WebMobile.Data.ViewModels;
using WebMobile.Models;

namespace WebMobile.Data.Services
{
    public interface IMobileService : IEntityBaseRepository<Mobile>
    {
        Task<Mobile> GetMobileByIdAsync(int id);
        Task<NewMobileDropdowns> GetNewMobileDropdownsValues();
        Task AddNewMobileAsync(Mobile data);
        Task UpdateMobileAsync(Mobile data);
    }

}
