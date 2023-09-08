using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Configuration;

namespace WinFormsApp2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        ///  
        /// </summary>
        /// 

        public static List<Target> definedTargets = new List<Target>();
        [STAThread]
        static void Main()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

            definedTargets = config.GetSection("targets").Get<List<Target>>();
            // Create the logger.  Sinks, enrichers etc are specified in the config
            var serilogLoggerConfig = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();

            // Wrap the local serilog logger in a Microsoft.Extensions.Logging.ILogger so it can be passed
            // to to anything expecting an ILogger
            var _logger = new SerilogLoggerProvider(serilogLoggerConfig).CreateLogger(nameof(Program));

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}