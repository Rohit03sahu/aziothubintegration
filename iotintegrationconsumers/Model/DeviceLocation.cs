using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iotintegrationconsumers.Model
{
    public class DeviceLocation
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}
