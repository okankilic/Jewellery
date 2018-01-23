using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Data.Common.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Lütfen ürün adını giriniz")]
        public string Name { get; set; }

        [Display(Name = "Ürün Fiyatı")]
        [Required(ErrorMessage = "Lütfen ürün fiyatını giriniz")]
        public decimal Price { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        [Required(ErrorMessage = "Lütfen ürün açıklamasını giriniz")]
        public string Description { get; set; }


    }
}
