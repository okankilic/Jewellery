using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using Jewellery.Infrastructure.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Data.Common.Mappers
{
    public static class AccountMapper
    {
        public static AccountDTO MapToDTO(Account account)
        {
            return new AccountDTO()
            {
                Id = account.Id,
                FullName = account.FullName,
                MobilePhone = account.MobilePhone,
                //Password = account.Password,
                Role = account.Role
            };
        }

        public static Account MapToEntity(AccountDTO account)
        {
            return new Account()
            {
                Id = account.Id,
                FullName = account.FullName.TrimIfNotNullOrWhiteSpace(),
                MobilePhone = account.MobilePhone.TrimIfNotNullOrWhiteSpace(),
                Password = account.Password.TrimIfNotNullOrWhiteSpace(),
                Role = account.Role.TrimIfNotNullOrWhiteSpace()
            };
        }
    }
}
