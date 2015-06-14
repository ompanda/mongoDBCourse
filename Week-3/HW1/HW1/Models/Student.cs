using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HW1.Models
{
    public class Student
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.Double)]
        public double Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("scores")]
        public List<Score> Scores { get; set; }

        public Student()
        {
            Scores = new List<Score>();
        }
    }
}
