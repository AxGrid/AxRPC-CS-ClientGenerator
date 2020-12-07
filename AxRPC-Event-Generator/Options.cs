using CommandLine;

namespace AxRPCEventGenerator
{
    public class Options
    {
        [Option('v', "verbose", Required = false, Default = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
        
            
        [Option('j', "json", Required = true, HelpText = "Path to json")]
        public string Json { get; set; }

        [Option('p', "entryPoint", Required = false, Default = "", HelpText = "Add additional Path")]
        public string EntryPointPath { get; set; }

        [Option('t', "template", Required = false, Default = Templates.UniRx, HelpText = "Template")]
        public Templates Template { get; set; }
        
        [Option('f', "file-template", Required = false, Default = "", HelpText = "External Template File")]
        public string TemplateFilePath { get; set; }
        
        [Option('n', "protobufNs", Required = false, Default = "AxGrid.Internal.Proto", HelpText = "Default protobuf namespace")]
        public string ProtobufNs { get; set; }

        [Option('s', "serviceNs", Required = false, Default = "AxGrid.Internal", HelpText = "Default service namespace")]
        public string ServiceNs { get; set; }

        [Option('o', "output", Required = false, HelpText = "Output folder")]
        public string Output { get; set; }
        
        [Option("timeout", Required = false, Default=60000, HelpText = "Timeout")]
        public int Timeout { get; set; }
        
        [Option('d', "debug", Required = false, Default = false, HelpText = "Add debug log into call.")]
        public bool Debug { get; set; }
        
        public string JsonData { get; set; }
        
        public enum Templates {
            CS,
            UniRx,
            Ext,
            JS
        }

    }
    

}