using Serilog;
using System.Web.Mvc;

namespace TaxiBooking.App_Start
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception, "An unhandled exception occurred.");

            context.Result = new ViewResult { ViewName = "Error" }; // Replace with your error handling logic
            context.ExceptionHandled = true;
        }
    }
}