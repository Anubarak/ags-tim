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

        public EHWInput hWInputType => EHWInput.HopScotch;

        private bool available = false;

        public Delegate[] GetButtonPressedMethodsAndUnsubscribe()
        {
            throw new NotImplementedException();
        }
    }
}