using CourseProjectBL.Actions;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace CourseProjectBL.Model
{
    public class User
    {
        public User()
        {

        }

        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Income> Incomes { get; set; } = new List<Income>();
        public List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
