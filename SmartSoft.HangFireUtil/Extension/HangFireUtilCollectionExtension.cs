using Hangfire;
using Hangfire.SQLite;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSoft.HangFireUtil.Extension
{
    public static class HangFireUtilCollectionExtension
    {
        public static IServiceCollection AddHangFireUtil(this IServiceCollection services, string datasource = "Data Source=./Hangfire.db;")
        {
            services.AddHangfire(x => x.UseSQLiteStorage(datasource, new SQLiteStorageOptions()));

            services.AddHangfireServer();

            return services;
        }

    }
}
