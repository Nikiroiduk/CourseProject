using CourseProjectBL.Enum;
using System;

namespace CourseProjectBL.Action
{
    public class Income : AbstractAction
    {
        public Income(DateTime dateTime, Account account, Category category, double amount, string note = "") : base(dateTime, account, category, amount, note)
        {
        }
    }
}
