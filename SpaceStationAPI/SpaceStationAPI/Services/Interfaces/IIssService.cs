using SpaceStationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceStationAPI.Services
{
  public   interface  IIssService
    {
        List<IssNow> addData(IssNow issNow);
    }
}
