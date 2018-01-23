using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jewellery.Presentation.WebUI.Models
{
    public abstract class AccountBaseViewModel
    {
        [Display(Name = "Cep Telefonu")]
        [Phone(ErrorMessage = "Lütfen geçerli bir cep telefonu numarası giriniz")]
        [Required(ErrorMessage = "Lütfen cep telefonu numaranızı giriniz")]
        public string MobilePhone { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}