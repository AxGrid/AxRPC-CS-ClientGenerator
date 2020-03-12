using CommandLine;

namespace AxRPCClientGenerator {
    public class Options {
        [Option('v', "verbose", Required = false, Default = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
            
        [Option('j', "json", Required = true, HelpText = "Path to json")]
        public string Json { get; set; }

        [Option('p', "entryPoint", Required = true, HelpText = "Add additional Path")]
        public string EntryPointPath { get; set; } = "";

        [Option('t', "template", Required = false, Default = Templates.UniRx, HelpText = "Template")]
        public Templates Template { get; set; }
        
        [Option('f', "file-template", Required = false, Default = "", HelpText = "External Template File")]
        public string TemplateFilePath { get; set; }
        
        [Option('p', "protobufNs", Required = false, Default = "AxGrid.Internal.Proto", HelpText = "Default protobuf namespace")]
        public string ProtobufNs { get; set; }

        [Option('s', "serviceNs", Required = false, Default = "AxGrid.Internal", HelpText = "Default service namespace")]
        public string ServiceNs { get; set; }

        [Option('o', "output", Required = false, HelpText = "Output folder")]
        public string Output { get; set; }
        
        [Option("retryCount", Required = false, Default=10, HelpText = "Generate Retry count")]
        public int RetryCount { get; set; }

        [Option("retryTimeout", Required = false, Default=200, HelpText = "Retry delay")]
        public int RetryTimeout { get; set; }

        [Option("serviceName", Required = false, Default = "", HelpText = "Create single Service class")]
        public string ServiceName { get; set; }
        
        [Option('e', "excludeCommons", Required = false, Default = false, HelpText = "Exclude Configuration, Exceptions, etc.")]
        public bool ExcludeCommons { get; set; }
        
        public string JsonData { get; set; }

        public enum Templates {
            CS,
            UniRx,
            Ext
        }
        
    }
}