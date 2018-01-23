using Jewellery.Data.JewelleryDBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.BusinessLogic
{
    public static class TokenBL
    {
        public static string Create(int accountId, JewelleryDBEntities db)
        {
            var token = new Token()
            {
                AccountId = accountId,
                TokenString = Guid.NewGuid().ToString(),
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(30)
            };

            db.Token.Add(token);

            db.SaveChanges();

            return token.TokenString;
        }

        public static Token TryGet(string tokenString, JewelleryDBEntities db)
        {
            return db.Token.SingleOrDefault(q => q.TokenString == tokenString && q.StartTime <= DateTime.Now && q.EndTime >= DateTime.Now);
        }
    }
}
