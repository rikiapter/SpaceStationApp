using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceStationAPI.Model
{
   // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class IssPosition
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

        public class IssNow
        {
            public int timestamp { get; set; }
            public IssPosition iss_position { get; set; }
            public string message { get; set; }
        }


    
}
