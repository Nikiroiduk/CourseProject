using CourseProjectBL.Enum;
using System;

namespace CourseProjectBL.Action
{
    class Expense : IAction
    {
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string Note { get; set; }
        public Category Category { get; set; }
        public Account Account { get; set; }
    }
}
