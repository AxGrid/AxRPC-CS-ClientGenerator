using System;
using System.IO;
using System.Net;
using CommandLine;
using SimpleLogger;
using SimpleLogger.Logging.Handlers;

namespace AxRPCEventGenerator
{
    internal class Program
    {
        public static string GetFromHttp(string url) {
            var request = HttpWebRequest.Create(url);
            try {
                var response = request.GetResponse();
                using (var sr = new StreamReader(response.GetResponseStream())) {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e) {
                Logger.Log(e);
                Environment.Exit(5);
            }
            return null;
        }
        
        public static void Main(string[] args)
        {
            Logger.LoggerHandlerManager
                .AddHandler(new ConsoleLoggerHandler());
            Logger.DefaultLevel = Logger.Level.Info;
            Logger.DebugOff();

            Parser.Default.ParseArguments<Options>(args).WithParsed(o =>
            {
                if (o.Verbose) Logger.DebugOn();
                if (o.Json.StartsWith("http")) {
                    Logger.Log($"Loading json from HTTP {o.Json}");
                    o.JsonData = GetFromHttp(o.Json);
                    new EventGenerator(o);
                }
                else {
                    Logger.Log($"Loading json from {o.Json}");
                    o.JsonData = File.ReadAllText(o.Json);
                    new EventGenerator(o);
                }
            });
        }
    }
}