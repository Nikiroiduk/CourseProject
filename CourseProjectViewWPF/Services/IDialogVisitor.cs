using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectViewWPF.Services
{
    public interface IDialogVisitor
    {
        object DynamicVisit(object data);
    }
}
