using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebMobile.Data.Base;

namespace WebMobile.Models
{
    public class Operating_System : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Operating_SystemPictureURL")]
        [Required(ErrorMessage = "Operating System Picture is required")]
        public string Operating_SystemPictureURL { get; set; }

        [Display(Name = "Operating_SystemName")]
        [Required(ErrorMessage = "Operating System Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Operating System Name must be between 3 and 50 chars")]
        public string Operating_SystemName { get; set; }
        public List<Mobile> Mobiles { get; set; }

    }
}
