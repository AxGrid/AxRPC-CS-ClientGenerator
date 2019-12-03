using System.Collections.Generic;

namespace AxRPCClientGenerator.Data {
    public class Service {
        public string ErrorCodeFieldName { get; set; }
        public string CorrelationIdFieldName { get; set; }
        public string SuccessFieldName { get; set; }
        public string ErrorTextFieldName { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        
        public List<Method> Methods { get; set; }

        public override string ToString() {
            return
                $"{Name} ({ErrorCodeFieldName} / {CorrelationIdFieldName} / {SuccessFieldName} / {ErrorTextFieldName}) Methods:{Methods.Count}";
        }
    }
}