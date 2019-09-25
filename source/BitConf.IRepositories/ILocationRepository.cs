using System;
using System.Collections;
using System.Collections.Generic;
using BitConf.Models;

namespace BitConf.IRepositories
{
    public interface ILocationService
    {
        void Add(Location location);
        Location Get(string vehicleId);
        IEnumerable<LocationInfo> Get(Location location, double distance = 1000);
    }
}
