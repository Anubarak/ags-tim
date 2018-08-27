using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGS_Tim.controllers
{
    public class Numpad : InputController
    {
        public bool Available { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<InputController> Disconnected;
        public event EventHandler<int> ButtonPressed;
    }
}
