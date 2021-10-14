using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSoft.HangFireUtil.Common
{
    public interface IBackgroundWorkerDo
    {
        #region DoWorkAsync
        /// <summary>
        /// execute real task
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task DoWorkAsync(PerformContext context);
        #endregion
    }
}
