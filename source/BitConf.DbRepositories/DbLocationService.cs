using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BitConf.IRepositories;
using BitConf.Models;
using StackExchange.Redis;

namespace BitConf.DbRepositories
{

    // dotnet add package StackExchange.Redis
    public class DbLocationService : ILocationService
    {
        private readonly IDatabase db;

        private const string locationsKey = "locations";

        public DbLocationService(IConnectionMultiplexer connection)
        {
            this.db = connection.GetDatabase();
        }

        public void Add(Location location)
        {
            // GEOADD key lat lng member
            db.GeoAdd(locationsKey, location.Latitude, location.Longitude, location.VehicleId);
        }

        public Location Get(string vehicleId)
        {
            // GEOPOS key member
            var position = db.GeoPosition(locationsKey, vehicleId);

            if (position == null)
                return null;

            var location = Map(position.Value);

            return location;
        }

        public IEnumerable<LocationInfo> Get(Location location, double distance)
        {
            // GEORADIUS  key 
            var geoResults = db.GeoRadius(locationsKey, location.Longitude, location.Latitude, distance, GeoUnit.Kilometers, -1, Order.Ascending, GeoRadiusOptions.WithCoordinates | GeoRadiusOptions.WithDistance);

            var results = geoResults.Select(g => Map(g));

            return results;

        }

        private static Location Map(GeoPosition position) => new Location
        {
            Latitude = position.Latitude,
            Longitude = position.Longitude
        };

        private static LocationInfo Map(GeoRadiusResult g) => new LocationInfo
        {
            VehicleId = g.Member,
            Distance = g.Distance.Value,
            Latitude = g.Position.Value.Latitude,
            Longitude = g.Position.Value.Longitude
        };
    }
}