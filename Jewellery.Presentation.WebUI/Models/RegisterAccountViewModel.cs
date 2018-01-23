using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jewellery.Presentation.WebUI.Models
{
    public class RegisterAccountViewModel: AccountBaseViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı ve soyadınızı giriniz")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }
    }
}