using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMobile.Data;
using WebMobile.Models;

namespace WebMobile.Services
{
    public class CompanyService : ICompanyServices
    {
        private readonly AppDbContext _context;
        public CompanyService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            var result = await _context.Companies.ToListAsync();
            return result;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            var result = await _context.Companies.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public Company Update(int id, Company newcompany)
        {
            throw new System.NotImplementedException();
        }
    }
}