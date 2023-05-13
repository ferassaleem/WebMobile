using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace WebMobile.Data.ViewModels
{
    public class NewMobile
    {
        public int Id { get; set; }

        [Display(Name = "MobilePictureURL")]
        [Required(ErrorMessage = "Mobile Picture URL is required")]
        public string MobilePictureURL { get; set; }

        [Display(Name = "MobileName ")]
        [Required(ErrorMessage = "Mobile Name is required")]
        public string MobileName { get; set; }

        [Display(Name = "Processor")]
        [Required(ErrorMessage = "Processor is required")]
        public string Processor { get; set; }

        [Display(Name = "RAM")]
        [Required(ErrorMessage = "RAM is required")]
        public string RAM { get; set; }

        [Display(Name = "Camera")]
        [Required(ErrorMessage = "Camera is required")]
        public string Camera { get; set; }

        [Display(Name = "Screen")]
        [Required(ErrorMessage = "Screen is required")]
        public string Screen { get; set; }

        [Display(Name = "Battery")]
        [Required(ErrorMessage = "Battery is required")]
        public string Battery { get; set; }

        //Relationships

        //Operating
        [Display(Name = "OperatingId")]
        [Required(ErrorMessage = "Operating System is required")]
        public int OperatingId { get; set; }

        //Company
        [Display(Name = "CompanyId")]
        [Required(ErrorMessage = "Company is required")]
        public int CompanyId { get; set; }
    }
}
