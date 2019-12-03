using System.Collections.Generic;
using AxRPCClientGenerator.Data;
using Newtonsoft.Json;
using SimpleLogger;

namespace AxRPCClientGenerator {
    public class GeneratorBase {
        protected static string GetServiceTemplate(Options.Templates template) => $"{template.ToString().ToLower()}-service-template.txt";

        protected List<Service> Services { get; set; }
        
        public GeneratorBase(Options o) {
            var t = TemplateLoader.GetTemplate(GetServiceTemplate(o.Template));
            Logger.Debug.Log(t.ToText());
            Services = JsonConvert.DeserializeObject<List<Service>> (o.JsonData);
            Logger.Debug.Log($"Found {Services.Count} service");
            Services.ForEach(service =>
            {
                Logger.Debug.Log($"{service.ToString()}");
            });
            
            var str = t.Render(new {
                Services = Services,
                Opt = o
            });
            
            Logger.Log(str);
        }
        
    }
}