using Hangfire;
using Microsoft.AspNetCore.Builder;
using SmartSoft.HangFireUtil.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSoft.HangFireUtil.Extension
{
    public static class HangFireUtilBuilderExtension
    {
        public static IApplicationBuilder UseHangFireUtil(this IApplicationBuilder app, string [] queues = null)
        {
            //add multiply Queues
            var jobOptions = new BackgroundJobServerOptions
            {
                Queues = queues ?? new[] { "default" }
            };
            app.UseHangfireServer(jobOptions);

            //enable DashBoard
            app.UseHangfireDashboard("/timedtask", new DashboardOptions
            {
                Authorization = new[]
               {
                    new HangfireAuthorizationFilter(){}
               }
            });
            return app;
        }

    }
}
