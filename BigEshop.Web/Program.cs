using NLog.Web;
using BigEshop.Web.Extensions;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args)
        .RegisterServices()
        .RegisterPipeLines();
}
catch(Exception? exception)
{
    logger.Error(exception, "Stopped Program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
