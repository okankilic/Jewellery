using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jewellery.Presentation.WebUI.Models
{
    public class CustomFormsAuthenticationUserData
    {
        public string TokenString { get; private set; }

        public string Role { get; private set; }

        public CustomFormsAuthenticationUserData(string tokenString, string role)
        {
            this.TokenString = tokenString;
            this.Role = role;
        }
    }
}