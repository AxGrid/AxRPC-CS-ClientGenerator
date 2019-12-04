namespace AxRPCClientGenerator.Data {
    public class Method {
        public string Name { get; set; }
        public string RequestFullName { get; set; }
        public string ResponseFullName { get; set; }
        
        public string RequestName { get; set; }
        public string ResponseName { get; set; }
       
        public bool LoginRequired { get; set; }
        public bool TrxRequired { get; set; }
        public bool EmptyRequest { get; set; }

    }
}