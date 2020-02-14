using System.Collections.Generic;
using System.IO;
using System.Linq;
using AxRPCClientGenerator.Data;
using Newtonsoft.Json;
using Scriban;
using SimpleLogger;

namespace AxRPCClientGenerator {
    public class GeneratorBase {
        
        protected static string GetServiceTemplate(Options.Templates template) => $"{template.ToString().ToLower()}-service-template.txt";

        protected List<Service> Services { get; set; }
        
        public GeneratorBase(Options o)
        {
            var t = o.Template == Options.Templates.Ext ? 
                TemplateLoader.GetTemplate(o.TemplateFilePath, true) : 
                TemplateLoader.GetTemplate(GetServiceTemplate(o.Template));
            Services = JsonConvert.DeserializeObject<List<Service>> (o.JsonData);
            Logger.Debug.Log($"Found {Services.Count} service");

            if (!string.IsNullOrEmpty(o.ServiceName) && Services.Count > 0) {
                var methods = Services.SelectMany(item => item.Methods).ToList();
                var s = Services[0];
                s.Name = o.ServiceName;
                s.Methods = methods;
                Services = new List<Service>(new [] {s});
            }


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