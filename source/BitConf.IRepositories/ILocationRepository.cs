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

    public interface IVehicleService
    {
        void Add(Vehicle vehicle);
        Vehicle Get(string vehicleId);
        void Rent(string vehicleId);
        void Return(string vehicleId);
        bool CanRest(string vehicleId);
        bool CanReturn(string vehicleId);
    }
}
