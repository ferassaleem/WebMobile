﻿using System.Threading.Tasks;
using WebMobile.Data.Base;
using WebMobile.Data.ViewModels;
using WebMobile.Models;

namespace WebMobile.Data.Services
{
    public interface IMobile_Service : IEntityBaseRepository<Mobile>
    {
        Task<Mobile> GetMobileByIdAsync(int id);
        Task<NewMobileDropdowns> GetNewMobileDropdownsValues();
        Task AddNewMobileAsync(NewMobile data);
        Task UpdateMobileAsync(NewMobile data);
    }

}
