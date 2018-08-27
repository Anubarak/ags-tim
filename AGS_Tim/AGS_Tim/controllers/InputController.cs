using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGS_Tim.controllers
{
    public interface InputController
    {
        bool Available { get; set; }

        event EventHandler<InputController> Disconnected;

        event EventHandler<int> ButtonPressed;
    }
}
