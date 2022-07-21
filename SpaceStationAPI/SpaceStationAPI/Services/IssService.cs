using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpaceStationAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceStationAPI.Services
{
  public class IssService: IIssService
    {
        private AppSettings Settings { get; }
        public IssService(IOptions<AppSettings> settings)
        {
            Settings = settings.Value;
        }
        public List<IssNow > addData(IssNow issNow)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = System.IO.Path.Combine(path, Settings.DataFile);
           
            string data = File.ReadAllText(path);
            List<IssNow> issNows = JsonConvert.DeserializeObject<List<IssNow>>(data)?? new List<IssNow> ();
           
            issNows.Add(issNow);
            var json = JsonConvert.SerializeObject(issNows);
            File.WriteAllText(path, json);

      
            return issNows;
        }
    }
}
