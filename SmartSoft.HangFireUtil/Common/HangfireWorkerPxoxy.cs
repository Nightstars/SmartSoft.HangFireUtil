using Hangfire;
using Hangfire.Common;
using Hangfire.SQLite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartSoft.HangFireUtil.Common
{
    public class HangfireWorkerPxoxy: BackgroundService
    {

        #region initialize
        private readonly IConfiguration _appConfiguration;
        private readonly WorkerConfig _config;
        private string _datasource = null;
        public HangfireWorkerPxoxy(IConfiguration appConfiguration, WorkerConfig Config,string datasource = "Data Source=./Hangfire.db;")
        {
            _appConfiguration = appConfiguration;
            _config = Config;
            _datasource = datasource;
        }
        #endregion

        #region Excete<T>
        /// <summary>
        /// Excetes this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Excete<T>() where T : IBackgroundWorkerDo
        {
            var connString = _datasource;
            JobStorage.Current = new SQLiteStorage(connString);
            var manager = new RecurringJobManager(JobStorage.Current);
            manager.RemoveIfExists(_config.WorkerId);
            manager.AddOrUpdate(_config.WorkerId, Job.FromExpression<T>((t) => t.DoWorkAsync(null)), string.IsNullOrEmpty(_config.Cron) ? Cron.MinuteInterval(_config.IntervalSecond / 60) : _config.Cron, TimeZoneInfo.Local, string.IsNullOrEmpty(_config.QueuesName) ? "default" : _config.QueuesName);
        }
        #endregion

        #region ExecuteAsync
        /// <summary>
        /// This method is called when the <see cref="T:Microsoft.Extensions.Hosting.IHostedService" /> starts. The implementation should return a task that represents
        /// the lifetime of the long running operation(s) being performed.
        /// </summary>
        /// <param name="stoppingToken">Triggered when <see cref="M:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)" /> is called.</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task" /> that represents the long running operations.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
