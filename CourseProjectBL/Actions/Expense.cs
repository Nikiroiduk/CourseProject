using CourseProjectBL.Enum;
using System;

namespace CourseProjectBL.Actions
{
    public class Expense : Action
    {
        public Expense(DateTime dateTime, Account account, Category category, double amount, string note = "") : base(dateTime, account, category, amount, note)
        {
        }
    }
}
