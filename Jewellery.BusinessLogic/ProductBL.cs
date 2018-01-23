using Jewellery.Data.Common.Mappers;
using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using Jewellery.Infrastructure.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.BusinessLogic
{
    public static class ProductBL
    {
        public static int Create(ProductDTO product, JewelleryDBEntities db)
        {
            var newProduct = ProductMapper.MapToEntity(product);

            db.Product.Add(newProduct);

            db.SaveChanges();

            NexmoSMSHelper.SendSMS();
            //TwilioSMSHelper.SendSMS("Korkma, bu bi test mesaji :)");

            return newProduct.Id;
        }

        public static ProductDTO Get(int id, JewelleryDBEntities db)
        {
            var product = db.Product.Single(q => q.Id == id);

            return ProductMapper.MapToDTO(product);
        }

        public static IEnumerable<ProductDTO> GetList(JewelleryDBEntities db)
        {
            return db.Product.ToList().Select(q => ProductMapper.MapToDTO(q));
        }

        public static void Update(int id, ProductDTO product, JewelleryDBEntities db)
        {
            throw new NotImplementedException();
        }

        public static void Delete(int id, JewelleryDBEntities db)
        {
            throw new NotImplementedException();
        }
    }
}
