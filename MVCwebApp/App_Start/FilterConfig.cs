using MVCwebApp.Filters;
using System.Web;
using System.Web.Mvc;

namespace MVCwebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new EmployeeExceptionFilter());
        }
    }
}
