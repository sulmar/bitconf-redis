using System;
using System.Collections.Generic;
using System.Text;

namespace BitConf.Models
{
    public class Rent : Base
    {
        public int Id { get; set; }
        public string VehicleId { get; set; }
        public string UserId { get; set; }
    }
}
