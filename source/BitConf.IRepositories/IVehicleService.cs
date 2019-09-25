using BitConf.Models;

namespace BitConf.IRepositories
{
    public interface IVehicleService
    {
        void Add(Vehicle vehicle);
        Vehicle Get(string vehicleId);
   
    }
}
