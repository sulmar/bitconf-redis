using BitConf.Models;

namespace BitConf.IRepositories
{
    public interface IRentService
    {
        void Rent(Rent rent);
        void Return(Rent rent);
        bool CanRent(string vehicleId);
        bool CanReturn(string vehicleId);
    }
}
