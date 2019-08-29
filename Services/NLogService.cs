using Dijing.Common.Core.Utility;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NLogDemo.Services
{
    public class NLogService : BackgroundService
    {
        public NLogService()
        {
            this._Logger = NLog.LogManager.GetCurrentClassLogger();
        }
        private NLog.ILogger _Logger { get; set; }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                try
                {
                    LogEventInfo ei = new LogEventInfo();
                    ei.Level = LogLevel.Warn;
                    ei.Properties["c1"] = "NLogDemo";
                    ei.Properties["c2"] = "NLog服务循环检测";
                    _Logger.Log(ei);



                    //_Logger.Warn("{@value}",new LogContent() { From = "NLogDemo", Title = "NLog服务循环检测" });                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"NLogService error,{ex.Message}");
                    LogHelper.Default.LogDay($"NLogService error,{ex}");
                }

                Task.Delay(3000).Wait();
            }
        }
    }

    public class LogContent
    {
        public string From { get; set; }
        public string Title { get; set; }
    }
}
