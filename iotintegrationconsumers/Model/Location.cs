using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace iotintegrationconsumers.Model
{
    public class Location
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("DeviceId")]
        public string DeviceId { get; set; }
        [BsonElement("DeviceName")]
        public string DeviceName { get; set; }
        [BsonElement("Lat")]
        public string Lat { get; set; }
        [BsonElement("Long")]
        public string Long { get; set; }
        [BsonElement("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

        public Location()
        {
            ID = ObjectId.GenerateNewId();
        }
    }
}
