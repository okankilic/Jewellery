using Jewellery.Data.Common.Mappers;
using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.BusinessLogic
{
    public static class AccountBL
    {
        public static int Create(AccountDTO account, JewelleryDBEntities db)
        {
            var newAccount = AccountMapper.MapToEntity(account);

            db.Account.Add(newAccount);
            db.SaveChanges();

            return newAccount.Id;
        }

        public static void Update(int accountId, Account account, JewelleryDBEntities db)
        {
            var existingAccount = db.Account.Single(q => q.Id == accountId);

            existingAccount.MobilePhone = account.MobilePhone;
            existingAccount.Password = account.Password;

            db.SaveChanges();
        }

        public static void Delete(int accountId, JewelleryDBEntities db)
        {
            var existingAccount = db.Account.Single(q => q.Id == accountId);

            db.Account.Remove(existingAccount);

            db.SaveChanges();
        }

        public static string Login(string mobilePhone, string password, JewelleryDBEntities db)
        {
            var account = db.Account.Single(q => q.MobilePhone == mobilePhone && q.Password == password);

            var tokenString = TokenBL.Create(account.Id, db);

            return tokenString;
        }

        public static AccountDTO GetByTokenString(string tokenString, JewelleryDBEntities db)
        {
            var token = TokenBL.TryGet(tokenString, db);
            if (token != null)
            {
                var account = db.Account.Single(q => q.Id == token.AccountId);
                return AccountMapper.MapToDTO(account);
            }

            return null;
        }

        internal static AccountDTO TryGet(int id, JewelleryDBEntities db)
        {
            var account = db.Account.SingleOrDefault(q => q.Id == id);

            if (account == null)
                return null;

            return AccountMapper.MapToDTO(account);
        }

        public static bool IsAccountExists(AccountDTO account, JewelleryDBEntities db)
        {
            return db.Account.Any(q => q.MobilePhone == account.MobilePhone && q.Password == account.Password);
        }

        public static IEnumerable<AccountDTO> GetList(JewelleryDBEntities db)
        {
            return db.Account.ToList().Select(q => AccountMapper.MapToDTO(q));
        }
    }
}
