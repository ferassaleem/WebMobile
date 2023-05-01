using System.Collections.Generic;
using System.Threading.Tasks;
using WebMobile.Models;

namespace WebMobile.Services
{
    public interface ICompanyServices
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetByIdAsync(int id);
        Task AddAsync(Company company);
        Company Update(int  id, Company newcompany);
        void Delete(int id);
    }
}
