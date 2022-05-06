using CourseProjectBL.Enum;
using System;

namespace CourseProjectBL.Actions
{
    public class Action
    {
        public Action(ActionType actionType, DateTime dateTime, Account account, Category category, double amount, string note = " ")
        {
            ActionType = actionType;
            DateTime = dateTime;
            Account = account;
            Category = category;
            Amount = amount;
            Note = note;
        }

        public Action(ActionType actionType, Account account, Category category, double amount, string note = " ")
        {
            ActionType = actionType;
            DateTime = DateTime.Now;
            Account = account;
            Category = category;
            Amount = amount;
            Note = note;
        }

        public Action()
        {
            DateTime = DateTime.Now;
        }

        public ActionType ActionType { get; set; }
        public DateTime DateTime { get; set; }
        public Account Account { get; set; }
        public Category Category { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }

    }
}
