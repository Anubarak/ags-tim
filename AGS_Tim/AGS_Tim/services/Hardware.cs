using AGS_Tim.controllers;
using AGS_Tim.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AGS_Tim.services
{
    public class Hardware
    {
        /// <summary> Service responsible for managing the input devices. </summary>
        /// <param name="mainWindow"></param>
        public Hardware(Window mainWindow)
        {
            // Numpad
            Numpad numpad = new Numpad(mainWindow);
            numpad.Connected += HWInput_Connected;
            numpad.Disconnected += HWInput_Disconnected;
            if (numpad.Available)
                availableHWInputs.Add(EHWInput.Keyboard);
            inputControllers.Add(numpad);
            
      
        }

        private void HWInput_Disconnected(object sender, EHWInput e)
        {
            throw new NotImplementedException();
        }

        private void HWInput_Connected(object sender, EHWInput e)
        {
            throw new NotImplementedException();
        }

        private List<EHWInput> availableHWInputs = new List<EHWInput>();
        private List<InputController> inputControllers = new List<InputController>();
    }
}
