using CourseProjectBL.Enum;
using System;

namespace CourseProjectBL.Action
{
    public class Expense : AbstractAction
    {
        public Expense(DateTime dateTime, Account account, Category category, double amount, string note = "") : base(dateTime, account, category, amount, note)
        {
        }
    }
}
