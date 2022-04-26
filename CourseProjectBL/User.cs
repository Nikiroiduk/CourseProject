using CourseProjectBL.Actions;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace CourseProjectBL
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Actions.Action> Actions { get; set; } = new List<Actions.Action>();
    }
}
