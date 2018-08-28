using System;
using AGS_Tim.models;
using System.Linq;

namespace AGS_Tim.controllers
{
    public class HopscotchMat : InputController
    {
        /// <summary> Initializes a instance of the <see cref="HopscotchMat"/> class </summary>
        public HopscotchMat()
        {
            
        }

        public event EventHandler<int> ButtonPressed;

        public event EventHandler<EHWInput> Connected;

        public event EventHandler<EHWInput> Disconnected;

        public Delegate[] GetButtonPressedMethodsAndUnsubscribe()
        {
            throw new NotImplementedException();
        }

        public bool Available { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public EHWInput hWInputType => EHWInput.HopScotch;

        private bool available = false;
    }
}