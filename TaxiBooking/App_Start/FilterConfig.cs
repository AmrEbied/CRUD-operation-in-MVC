using System.Web;
using System.Web.Mvc;
using TaxiBooking.App_Start;

namespace TaxiBooking
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalExceptionFilter());
        }
    }
}
