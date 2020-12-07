using System;
using System.IO;
using System.Reflection;
using Scriban;
using SimpleLogger;

namespace AxRPCEventGenerator
{
    public static class TemplateLoader
    {
        public static string GetTemplateString(string name) {
            Logger.Debug.Log($"Load template {name}");
            try {
                using (var stream =
                    Assembly.GetExecutingAssembly().GetManifestResourceStream("AxRPCEventGenerator.templates."+name))
                using (var reader = new StreamReader(stream)) {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e) {
                Logger.Log(e);
                Environment.Exit(501);
            }

            return null;
        }
        
        public static string GetTemplateStringFromFS(string path) {
            Logger.Debug.Log($"Load template from path {path}");
            return File.ReadAllText(path);
        }
        
        public static Template GetTemplate(string name, bool fs = false) {
            return Template.Parse(fs ? GetTemplateStringFromFS(name) : GetTemplateString(name));
        }

    }
}