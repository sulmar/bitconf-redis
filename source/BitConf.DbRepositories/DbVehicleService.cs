using System;
using System.Collections.Generic;
using BitConf.IRepositories;
using BitConf.Models;
using StackExchange.Redis;

namespace BitConf.DbRepositories
{
    public class DbVehicleService : IVehicleService
    {
        private readonly IDatabase db;

        private const string vehiclesKey = "vehicles";
        private const string toRentkey = "to-rent";

        public DbVehicleService(IConnectionMultiplexer connection)
        {
            this.db = connection.GetDatabase();
        }

        public void Add(Vehicle vehicle)
        {
            // SADD key member
            db.SetAdd(toRentkey, vehicle.Id);
        }

        public Vehicle Get(string vehicleId)
        {
            throw new NotImplementedException();
        }

        public void Remove(string vehicleId)
        {
            db.SetRemove(toRentkey, vehicleId);
        }

      
    }
}