using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseControl.src.Action;

namespace CourseControl.src.Target
{
    interface ITargetable
    {
        void HandleAction(Action.Action action);
    }
}
