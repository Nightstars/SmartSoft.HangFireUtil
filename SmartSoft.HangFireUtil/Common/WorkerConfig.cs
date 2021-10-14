using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSoft.HangFireUtil.Common
{
    public class WorkerConfig
    {
        /// <summary>
        /// 轮询秒数
        /// </summary>
        public int IntervalSecond { get; set; }
        /// <summary>
        /// 工作唯一编号
        /// </summary>
        public string WorkerId { get; set; }
        /// <summary>
        /// 队列名称
        /// </summary>
        public string QueuesName { get; set; }
        /// <summary>
        /// 表达式
        /// </summary>
        public string Cron { get; set; }
    }
}
