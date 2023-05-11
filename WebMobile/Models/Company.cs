using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebMobile.Data.Base;

namespace WebMobile.Models
{
    public class Company : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "CompanyPictureURL")]
        [Required (ErrorMessage = "Company Picture is required")]
        public string CompanyPictureURL { get; set; }

        [Display(Name = "CompanyName")]
        [Required(ErrorMessage = "Company Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Company Name must be between 3 and 50 chars")]
        public string CompanyName { get; set; }
        public List<Mobile> Mobiles { get; set; }



    }
}


//class User {
// prop int Id{get set}
// prop string psss{get set} =string.Empty; 
// prop string password
// [Compare ="password"] 
// prop string conpassword
//[EmailAdderss]
//} prop string Email