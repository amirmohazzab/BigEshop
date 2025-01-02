using BigEshop.Web.Jobs;
using Quartz;
using Quartz.AspNetCore;

namespace BigEshop.Web.Extensions
{
    public static class RegisterJobExtensions
    {
        public static IServiceCollection RegisterJobs(this IServiceCollection services)
        {
            services.AddQuartz(quartz =>
            {
                JobKey closeTicketsJobKey = new("closeTicketsJobKey");
                quartz.AddJob<CloseTicketsJob>(closeTicketsJobKey);
                quartz.AddTrigger(s =>
                {
                    s.StartNow().ForJob(closeTicketsJobKey)
                    .WithIdentity("closeTicketsJobKey")
                    .WithSimpleSchedule(sc => sc.RepeatForever().WithInterval(TimeSpan.FromSeconds(10)));
                });
            });

            services.AddQuartzServer(options => options.WaitForJobsToComplete = true);

            return services;
        }
    }
}
