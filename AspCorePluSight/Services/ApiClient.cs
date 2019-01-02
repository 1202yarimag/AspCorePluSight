using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web;
using System.Xml.Serialization;
using AspCorePluSight.Models;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;

namespace AspCorePluSight.Services
{
    public class ApiClient<T> : IApiClient<T>
    {
        private readonly HttpClient _client = new HttpClient();
        public ApiClient(int timeoutSeconds = 5, string apiUri = "")
        {
            //var apiPath = ConfigurationManager.AppSettings["apiBasePath"];
            var apiPath = @"http://www.tcmb.gov.tr/kurlar/today.xml";

            if (string.IsNullOrEmpty(apiUri)) apiUri = apiPath;

            if (timeoutSeconds == 5)
            {
                timeoutSeconds = 60;
            }
            if (timeoutSeconds > 0) _client.Timeout = new TimeSpan(0, 0, timeoutSeconds);
            _client.BaseAddress = new Uri(apiUri);

        }
        public HttpStatusCode StatusCode { get; private set; }

        public async Task<T> GetAsync(string relativePath)
        {
            var httpResponseMessage = await _client.GetAsync(relativePath);
            StatusCode = httpResponseMessage.StatusCode;
            if (!httpResponseMessage.IsSuccessStatusCode) return default(T);
            var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            //return await Task.Run(() => (T)serializer.ReadObject((responseBody));
            return await Task.Run(() =>
            {
                using (StringReader reader = new StringReader(responseBody))
                {
                    using (XmlReader xmlReader = XmlReader.Create(reader))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("Tarih_Date"));
                        T theObject = (T)serializer.Deserialize(xmlReader);
                        return theObject;
                    }
                }
            });
        }
    }
}
