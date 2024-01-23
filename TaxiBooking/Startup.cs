using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;

[assembly: OwinStartupAttribute(typeof(TaxiBooking.Startup))]
namespace TaxiBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
          .WriteTo.MSSqlServer(
              connectionString: "Data Source=.;Initial Catalog=TaxiBookingDB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
              sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true },
              columnOptions: new Serilog.Sinks.MSSqlServer.ColumnOptions { AdditionalColumns = new Collection<SqlColumn> { new SqlColumn { ColumnName = "User", DataType = SqlDbType.NVarChar, AllowNull = true } } }
          )
          .CreateLogger();
            ConfigureAuth(app);
        }
    }
}
