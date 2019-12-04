using System.Collections.Generic;

namespace AxRPCClientGenerator.Data {
    public class Service {
        public string ErrorCodeFieldName { get; set; }
        public string CorrelationIdFieldName { get; set; }
        public string SuccessFieldName { get; set; }
        public string ErrorTextFieldName { get; set; }
        
        public string TrxFieldName { get; set; }
        
        public string SessionFieldName { get; set; }
        
        public string Name { get; set; }
        public string FullName { get; set; }
        
        public string RequestObject { get; set; }
        public string ResponseObject { get; set; }

        public string RequestObjectFullName { get; set; }
        public string ResponseObjectFullName { get; set; }

        public List<Method> Methods { get; set; }

        public override string ToString() {
            return
                $"{Name} ({ErrorCodeFieldName} / {CorrelationIdFieldName} / {SuccessFieldName} / {ErrorTextFieldName} / {TrxFieldName}) Methods:{Methods.Count}";
        }
    }
}