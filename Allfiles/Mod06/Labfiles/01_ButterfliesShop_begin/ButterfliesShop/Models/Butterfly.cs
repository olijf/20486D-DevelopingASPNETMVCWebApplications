using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ButterfliesShop.Models
{
    public class Butterfly
    {
        public int Id { get; set; }
        [Display(Name = "Common Name")]
        [Required(ErrorMessage = "Please enter Butterfly name")]
        public string CommonName { get; set; }
        [Display(Name = "Butterfly Family:")]
        [Required(ErrorMessage = "Please enter Butterfly family")]
        public Family? ButterflyFamily { get; set; }
        [Display(Name = "Butterflies Quantity:")]
        [Required(ErrorMessage = "Please enter Butterfly quantity")]
        public int? Quantity { get; set; }
        [Display(Name = "Characteristics:")]
        [Required(ErrorMessage = "Please enter Butterfly characteristics")]
        [StringLength(maximumLength: 50)]
        public string Characteristics { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Updated on:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Butterflies Picture:")]
        [Required(ErrorMessage ="Please select the butterflies picture")]
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }
    }
}
