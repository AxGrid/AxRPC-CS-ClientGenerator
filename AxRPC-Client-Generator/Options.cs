using CommandLine;

namespace AxRPCClientGenerator {
    public class Options {
        [Option('v', "verbose", Required = false, Default = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
            
        [Option('j', "json", Required = true, HelpText = "Path to json")]
        public string Json { get; set; }
        
        [Option('t', "template", Required = false, Default = Templates.UniRx, HelpText = "Template")]
        public Templates Template { get; set; }
        
        [Option('p', "protobufNs", Required = false, Default = "AxGrid.Internal.Proto", HelpText = "Default protobuf namespace")]
        public string ProtobufNs { get; set; }

        [Option('s', "serviceNs", Required = false, Default = "AxGrid.Internal", HelpText = "Default service namespace")]
        public string ServiceNs { get; set; }

        
        public string JsonData { get; set; }

        public enum Templates {
            CS,
            UniRx
        }
        
    }
}