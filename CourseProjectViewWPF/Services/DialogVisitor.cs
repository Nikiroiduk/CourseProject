using CourseProjectViewWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = CourseProjectBL.Actions.Action;

namespace CourseProjectViewWPF.Services
{
    class DialogVisitor : IDialogVisitor
    {
        public object DynamicVisit(object data) => Visit((dynamic)data);

        private Action Visit(Action a)
        {
            NewActionWindow win = new();
            win.DataContext = a;
            if ((bool)win.ShowDialog())
                return a;
            return null;
        }
    }
}
