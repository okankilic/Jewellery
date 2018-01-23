using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Data.Common.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public string AccountFullName { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Lütfen ürün adedini giriniz")]
        public int Quantity { get; set; }

        public DateTime OrderTime { get; set; }

        public int? ResponsibleAccountId { get; set; }

        public string ResponsibleAccountFullName { get; set; }

        public string OrderState { get; set; }

        public string Remarks { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
