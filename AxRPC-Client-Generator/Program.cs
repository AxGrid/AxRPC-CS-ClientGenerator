
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
            Logger.DebugOff();
            
            Parser.Default.ParseArguments<Options>(args).WithParsed(o => {
                if (o.Verbose) Logger.DebugOn();
                if (o.Json.StartsWith("http")) {
                    Logger.Log($"Loading json from HTTP {o.Json}");
                    o.JsonData = Utils.GetFromHttp(o.Json);
                    new GeneratorBase(o);
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