﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebMobile.Data.Base;

namespace WebMobile.Models
{
    public class Operating : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "OperatingPictureURL")]
        [Required (ErrorMessage = "Operating Picture is required")]
        public string OperatingPictureURL { get; set; }

        [Display(Name = "OperatingName")]
        [Required(ErrorMessage = "Operating Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Operating Name must be between 3 and 50 chars")]
        public string OperatingName { get; set; }
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