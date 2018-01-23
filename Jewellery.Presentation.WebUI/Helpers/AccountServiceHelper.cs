using Jewellery.Data.Common.Models;
using Jewellery.Data.JewelleryDBEntities;
using Jewellery.Infrastructure.Core;
using Jewellery.Infrastructure.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Jewellery.Presentation.WebUI.Helpers
{
    //public static class AccountServiceHelper
    //{
    //    public static AccountDTO GetByTokenString(string tokenString)
    //    {
    //        var httpClient = new HttpClient();

    //        var response = httpClient.GetAsync(ApiUrlHelper.AccountGetByTokenStringUrl + "?tokenString=" + tokenString).Result;

    //        if (response.IsSuccessStatusCode == true)
    //            return response.Content.ReadAsAsync<AccountDTO>().Result;

    //        return null;
    //    }

    //    public static string Login(string mobilePhone, string password)
    //    {
    //        var httpClient = new HttpClient();

    //        var values = new Dictionary<string, string>()
    //        {
    //            { "mobilePhone", mobilePhone },
    //            { "password", password }
    //        };

    //        var content = new FormUrlEncodedContent(values);
            
    //        var response = httpClient.PostAsync(ApiUrlHelper.AccountLoginUrl, content).Result;

    //        if (response.IsSuccessStatusCode == true)
    //            return response.Content.ReadAsStringAsync().Result;

    //        return null;
    //    }

    //    public static int Create(string fullName, string mobilePhone, string password)
    //    {
    //        var account = new Account()
    //        {
    //            FullName = fullName,
    //            MobilePhone = mobilePhone,
    //            Password = password,
    //            Role = Roles.Customer
    //        };

    //        var httpClient = new HttpClient();

    //        var response = httpClient.PostAsJsonAsync<Account>(ApiUrlHelper.AccountCreateUrl, account).Result;

    //        if (response.IsSuccessStatusCode == true)
    //            return response.Content.ReadAsAsync<int>().Result;

    //        return 0;
    //    }
    //}
}