using AGS_Tim.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGS_Tim.controllers
{
    public class HopscotchMat : InputController
    {
        public event EventHandler<EHWInput> Disconnected;
        public event EventHandler<int> ButtonPressed;
        public event EventHandler<EHWInput> Connected;

        public bool Available { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private bool available = false;
    }
}
