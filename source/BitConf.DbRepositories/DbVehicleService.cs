using BitConf.IRepositories;
using BitConf.Models;
using StackExchange.Redis;

namespace BitConf.DbRepositories
{
    public class DbVehicleService : IVehicleService
    {
        private readonly IConnectionMultiplexer connection;
        private readonly IDatabase db;

        private const string vehiclesKey = "vehicles";

        public void Add(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public Vehicle Get(string vehicleId)
        {
            throw new System.NotImplementedException();
        }
    }
}