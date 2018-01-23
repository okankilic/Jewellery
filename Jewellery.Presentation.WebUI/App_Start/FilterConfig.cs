using Jewellery.Presentation.WebUI.Filters;
using System.Web;
using System.Web.Mvc;

namespace Jewellery.Presentation.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
            filters.Add(new CustomAuthenticateAttribute());
        }
    }
}
