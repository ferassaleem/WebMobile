using System.Collections.Generic;
using WebMobile.Models;

namespace WebMobile.Data.ViewModels
{
    public class NewMobileDropdowns
    {
        public NewMobileDropdowns()
        {
            Companies = new List<Company>();
            Operatings = new List<Operating>();
        }
        public List<Company> Companies { get; set; }
        public List<Operating> Operatings { get; set; }

    }
}
