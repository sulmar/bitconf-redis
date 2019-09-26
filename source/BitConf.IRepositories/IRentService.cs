using BitConf.Models;
using System.Collections.Generic;

namespace BitConf.IRepositories
{
    public interface IRentService
    {
        Rent Get(int id);
        void Rent(Rent rent);
        void Return(Rent rent);
        bool CanRent(string vehicleId);
        bool CanReturn(string vehicleId);

        int GetCount();

        IEnumerable<Vehicle> Get();
        IEnumerable<Vehicle> GetToRent();
        IEnumerable<Vehicle> GetRentedOut();
    }
}
