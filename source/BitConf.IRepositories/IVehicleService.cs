using BitConf.Models;
using System.Collections.Generic;

namespace BitConf.IRepositories
{
    public interface IVehicleService
    {
        void Add(Vehicle vehicle);
        Vehicle Get(string vehicleId);
        void Remove(string vehicleId);

    }
}
