using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Data.Common.Mappers
{
    public static class ProductMapper
    {
        public static Product MapToEntity(ProductDTO product)
        {
            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
        }

        public static ProductDTO MapToDTO(Product product)
        {
            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
        }
    }
}
