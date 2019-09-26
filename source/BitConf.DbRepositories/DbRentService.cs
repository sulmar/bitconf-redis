﻿using BitConf.IRepositories;
using BitConf.Models;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace BitConf.DbRepositories
{
    public class DbRentService : IRentService
    {
        private readonly IDatabase db;

        private const string toRentkey = "to-rent";
        private const string rentedOutKey = "rented-out";
        private const string rentCounterKey = "rent-counter";

        public DbRentService(IConnectionMultiplexer connection)
        {
            this.db = connection.GetDatabase();
        }

        public bool CanRent(string vehicleId)
        {
            return db.SetContains(toRentkey, vehicleId);
        }

        public bool CanReturn(string vehicleId)
        {
            return db.SetContains(rentedOutKey, vehicleId);
        }

        public void Rent(Rent rent)
        {
            rent.Id = (int) db.StringIncrement(rentCounterKey);

            db.SetMove(toRentkey, rentedOutKey, rent.VehicleId);
        }

        public void Return(Rent rent)
        {
            db.SetMove(rentedOutKey, toRentkey, rent.VehicleId);
        }

        private IEnumerable<Vehicle> Get(string key)
        {
            RedisValue[] values = db.SetMembers(key);

            var vehicles = values.Select(v => Map(v));

            return vehicles;
        }

        private static Vehicle Map(RedisValue value)
        {
            return new Vehicle { Id = value };
        }

        public IEnumerable<Vehicle> Get()
        {
            var values = db.SetCombine(SetOperation.Union, toRentkey, rentedOutKey);

            var vehicles = values.Select(v => Map(v));

            return vehicles;
        }

        public IEnumerable<Vehicle> GetToRent() => Get(toRentkey);

        public IEnumerable<Vehicle> GetRentedOut() => Get(rentedOutKey);

        public Rent Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
           return (int)db.StringGet(rentCounterKey);
        }
    }
}