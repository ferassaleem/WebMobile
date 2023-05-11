using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebMobile.Data.Base;

namespace WebMobile.Models
{
    public class Mobile : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "MobilePictureURL")]
        public string MobilePictureURL { get; set; }

        [Display(Name = "MobileName")]
        public string MobileName { get; set; }

        [Display(Name = "Processor")]
        public string Processor { get; set; }

        [Display(Name = "RAM")]
        public string RAM { get; set; }

        [Display(Name = "Camera")]
        public string Camera { get; set; }

        [Display(Name = "Screen")]
        public string Screen { get; set; }

        [Display(Name = "Battery")]
        public string Battery { get; set; }


        //OperatingSystem
        public int OperatingSystemId { get; set; }
        [ForeignKey("OperatingSystemId")]
        public Operating_System Operating_System { get; set; }
        
        //Company
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }




    }
}
