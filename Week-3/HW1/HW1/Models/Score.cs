using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace HW1.Models
{
    public class Score
    {
       [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("score")]
        public double Value { get; set; }
    }
}
