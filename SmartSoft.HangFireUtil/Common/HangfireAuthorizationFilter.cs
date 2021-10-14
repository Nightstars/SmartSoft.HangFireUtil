using Hangfire.Annotations;
using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSoft.HangFireUtil.Common
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {

        #region Authorize        
        /// <summary>
        /// Authorizes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public bool Authorize([NotNull] DashboardContext context)
        {
                return true;
        }
        #endregion
    }
}
