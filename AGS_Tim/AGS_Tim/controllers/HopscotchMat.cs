using System;
using AGS_Tim.models;
using System.Linq;
using SlimDX.DirectInput;

namespace AGS_Tim.controllers
{
    public class HopscotchMat : InputController
    {
        // Mapping : 1  2   3   4   5   6   7   8   9
        //           7  8   10  4   5   6   1   2   3

        /// <summary> Initializes a instance of the <see cref="HopscotchMat"/> class </summary>
        public HopscotchMat()
        {
            DirectInput input = new DirectInput();
            var devices = input.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AttachedOnly);
            if (devices.Count == 0)
                return;

            var hopscotchMatInstance = devices[0];
            hopscotchMat = new Joystick(input, hopscotchMatInstance.InstanceGuid);
            // wird angeblich benötigt für die Zugriffsart, braucht aber ein Control handle --> für Background sinnvoll?
            //hopscotchMat.SetCooperativeLevel();
            hopscotchMat.Acquire();
        }

        public event EventHandler<int> ButtonPressed;

        public event EventHandler<EHWInput> Connected;

        public event EventHandler<EHWInput> Disconnected;

        public Delegate[] GetButtonPressedMethodsAndUnsubscribe()
        {
            throw new NotImplementedException();
        }

        /// <summary> Shows that the controller is available </summary>
        public bool Available { get => hopscotchMat != null; }

        public EHWInput hWInputType => EHWInput.HopScotch;

        private bool available = false;
        private Joystick hopscotchMat;
    }
}