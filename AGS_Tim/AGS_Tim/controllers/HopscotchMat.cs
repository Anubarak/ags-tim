using AGS_Tim.models;
using System;

namespace AGS_Tim.controllers
{
    public class HopscotchMat : InputController
    {
        public event EventHandler<int> ButtonPressed;

        public event EventHandler<EHWInput> Connected;

        public event EventHandler<EHWInput> Disconnected;

        public bool Available { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private bool available = false;
    }
}