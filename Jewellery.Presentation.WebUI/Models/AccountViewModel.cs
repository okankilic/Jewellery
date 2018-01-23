using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jewellery.Presentation.WebUI.Models
{
    public class AccountViewModel: AccountBaseViewModel
    {
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}