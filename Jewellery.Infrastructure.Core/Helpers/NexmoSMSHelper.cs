using Nexmo.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Infrastructure.Core.Helpers
{
    public static class NexmoSMSHelper
    {
        public static void SendSMS()
        {
            var results = SMS.Send(new SMS.SMSRequest
            {
                from = "905424142484",
                to = "905424142484",
                text = "this is a test"
            });
        }
    }
}
