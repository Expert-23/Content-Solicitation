
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Loggingg
{
   public static class MasterLog
    {
        private static ILogger mLogger;

        public static ILogger MasterLogs()
        {
            if(mLogger == null) Initialize();
            return mLogger;
        }

        private static void Initialize()
        {
            Initialize_Logger_Direct();
        }

        public static void Initialize_Logger_Direct()
        {
            string classification = "normal";
            //string filepathLog = @"C:\Users\joeyj\OneDrive\Desktop\Output\serilog.txt";
            //string filepathLog = @"C:\Users\pc\source\repos\Expert-23\SWAP-23\BeyBarter.Complete\Loggingg\Logs.txt"; 
            string filepathLog = @"C:\Users\pc\source\repos\Expert-23\Content-Solicitation\z-cache\Logging\Logs.txt";
            string template = "[{Classification} {EnvironmentUserName} {ThreadName} {ProcessName} {MachineName} {Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}";

            mLogger = new LoggerConfiguration()
             .Enrich.WithEnvironmentUserName()
             .Enrich.WithMachineName()
             .Enrich.WithProperty("Classification", classification)
             .Enrich.WithProcessName()
             .MinimumLevel.Debug().WriteTo.File(filepathLog)
             .MinimumLevel.Debug().WriteTo.Seq("http://localhost:5341", apiKey: "qiYIiGkpVS6m9xOkzbRJ")
             .CreateLogger();
            
             
        }
   
    }

}
