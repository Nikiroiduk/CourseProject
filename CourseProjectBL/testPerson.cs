using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CourseProjectBL
{
    public class testPerson
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
