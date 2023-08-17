using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iotintegrationconsumers.Model
{
    internal class HubModel
    {
        public string MessageId { get; set; }
        public string Topic { get; set; }
        public string ChannelId { get; set; }
        public string DeviceId { get; set; }
        public string Payload { get; set; }
    }
}
