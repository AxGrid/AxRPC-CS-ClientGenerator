using System;
using System.IO;
using System.Net;
using SimpleLogger;

namespace AxRPCClientGenerator {
    public static class Utils {
        public static string GetFromHttp(string url) {
            var request = HttpWebRequest.Create(url);
            try {
                var response = request.GetResponse();
                using (var sr = new StreamReader(response.GetResponseStream())) {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e) {
                Logger.Log(e);
                Environment.Exit(5);
            }
            return null;
        }
    }
}