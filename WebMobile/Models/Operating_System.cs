using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMobile.Models
{
    public class Operating_System
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "OperatingPictureURL")]
        public string OperatingPictureURL { get; set; }

        [Display(Name = "OperatingName")]
        public string OperatingName { get; set;}

        //RelationShips
        public List<Mobile> Mobiles { get; set;}

    }
}
