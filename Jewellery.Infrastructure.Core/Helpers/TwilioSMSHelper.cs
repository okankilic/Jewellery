using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Jewellery.Infrastructure.Core.Helpers
{
    public static class TwilioSMSHelper
    {
        public static void SendSMS(string message)
        {
            // Your Account SID from twilio.com/console
            var accountSid = "AC8bb392b7a4395433ae0ebba8f22ad750";

            // Your Auth Token from twilio.com/console
            var authToken = "61de43d268f653dbdd867c116bb841a3";

            TwilioClient.Init(accountSid, authToken);

            MessageResource.Create(to: new PhoneNumber("+905424142484"),
                from: new PhoneNumber("+19103569062"),
                body: message);
        }
    }
}
