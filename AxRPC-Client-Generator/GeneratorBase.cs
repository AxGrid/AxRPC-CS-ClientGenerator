using System.Collections.Generic;
using System.IO;
using AxRPCClientGenerator.Data;
using Newtonsoft.Json;
using SimpleLogger;

namespace AxRPCClientGenerator {
    public class GeneratorBase {
        protected static string GetServiceTemplate(Options.Templates template) => $"{template.ToString().ToLower()}-service-template.txt";

        protected List<Service> Services { get; set; }
        
        public GeneratorBase(Options o) {
            
            var t = TemplateLoader.GetTemplate(GetServiceTemplate(o.Template));
            Services = JsonConvert.DeserializeObject<List<Service>> (o.JsonData);
            Logger.Debug.Log($"Found {Services.Count} service");
            Services.ForEach(service =>
            {
                Logger.Log($"{service.ToString()}");
            });
            
            var str = t.Render(new {
                Services,
                Opt = o
            });
            Logger.Debug.Log(str);
            if (string.IsNullOrEmpty(o.Output)) return;
            using (var sw = new StreamWriter(o.Output)) {
                sw.Write(str);
            }
        }
        
    }
}