
using System.IO;
using CommandLine;
using SimpleLogger;
using SimpleLogger.Logging.Handlers;

namespace AxRPCClientGenerator {
    internal class Program {
        
        public static void Main(string[] args) {
            Logger.LoggerHandlerManager
                  .AddHandler(new ConsoleLoggerHandler());
            Logger.DefaultLevel = Logger.Level.Info;
            Parser.Default.ParseArguments<Options>(args).WithParsed(o => {
                if (o.Verbose) Logger.DefaultLevel = Logger.Level.Debug;
                if (o.Json.StartsWith("http")) {
                    Logger.Log($"Loading json from HTTP {o.Json}");
                }
                else {
                    Logger.Log($"Loading json from {o.Json}");
                    o.JsonData = File.ReadAllText(o.Json);
                    new GeneratorBase(o);
                }
            });

        }
    }
}