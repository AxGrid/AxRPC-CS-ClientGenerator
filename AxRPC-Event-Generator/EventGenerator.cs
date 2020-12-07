using System.Collections.Generic;
using System.IO;
using AxRPCEventGenerator.Data;
using Newtonsoft.Json;
using Scriban;
using Scriban.Runtime;
using SimpleLogger;

namespace AxRPCEventGenerator
{
    public class EventGenerator
    {
        protected static string GetServiceTemplate(Options.Templates template) => $"{template.ToString().ToLower()}-event-template.txt";
        
        
        protected List<Event> Events { get; set; }
        public EventGenerator(Options o)
        {
            var t = o.Template == Options.Templates.Ext ? 
                TemplateLoader.GetTemplate(o.TemplateFilePath, true) : 
                TemplateLoader.GetTemplate(GetServiceTemplate(o.Template));
            Events = JsonConvert.DeserializeObject<List<Event>> (o.JsonData);
            Logger.Debug.Log($"Found {Events.Count} events");
            
            Events.ForEach(ev => {  Logger.Log($"{ev.ToString()}"); });
            
            var scriptObject1 = new ScriptObject();
            scriptObject1.Import(typeof(TemplateFunctions));
            scriptObject1.Import(new
            {
                Events,
                Opt = o
            });
            
            var context = new TemplateContext();
            context.PushGlobal(scriptObject1);  
            var str = t.Render(context);
            
            if (string.IsNullOrEmpty(o.Output))
            {
                Logger.Debug.Log(str);
                return;
            }

            using (var sw = new StreamWriter(o.Output)) {
                sw.Write(str);
            }
        }
    }
}