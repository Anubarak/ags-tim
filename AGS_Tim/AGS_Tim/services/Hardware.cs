using AGS_Tim.controllers;
using AGS_Tim.models;
using AGS_Tim.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AGS_Tim.services
{
    public class Hardware
    {
        /// <summary> Service responsible for managing the input devices. </summary>
        /// <param name="mainWindow"></param>
        public Hardware(MainWindow mainWindow)
        {
            // Numpad
            Numpad numpad = new Numpad(mainWindow as Window);
            numpad.Connected += HWInput_Connected;
            numpad.Disconnected += HWInput_Disconnected;
            if (numpad.Available)
                availableHWInputs.Add(EHWInput.Keyboard);
            inputControllers.Add(numpad);
            // HopScotch
            HopscotchMat mat = new HopscotchMat();
            mat.Connected += HWInput_Connected;
            mat.Disconnected += HWInput_Disconnected;
            if (mat.Available)
                availableHWInputs.Add(EHWInput.HopScotch);
            inputControllers.Add(mat);
            if (availableHWInputs.Count == 0)
                throw new Exception("No Input Devices found");
            activeController = inputControllers.Find(x => x.hWInputType == availableHWInputs.Max());
            activeController.ButtonPressed += mainWindow.ButtonPressed;
        }

        /// <summary> Returns the active Controller </summary>
        public InputController ActiveController { get => activeController; }

        /// <summary> Controls if the actvive Controller is from the most superior one and changes the Controller if it isn't </summary>
        private void GetNewActiveController()
        {
            EHWInput most = availableHWInputs.Max();
            if (activeController == null || activeController.hWInputType != most)
            {
                InputController old = activeController;
                activeController = inputControllers.Find(y => y.hWInputType == inputControllers.Max(x => x.hWInputType));
                reloadController(old);
            }
        }

        /// <summary> Adds the Connected device </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HWInput_Connected(object sender, EHWInput e)
        {
            if (!availableHWInputs.Contains(e))
            {
                availableHWInputs.Add(e);
                GetNewActiveController();
            }
        }

        /// <summary> Removes the disconnected device </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HWInput_Disconnected(object sender, EHWInput e)
        {
            availableHWInputs.Remove(e);
            if (e == activeController.hWInputType)
                GetNewActiveController();
        }

        /// <summary> Reloads the events from the old to the new Controller </summary>
        /// <param name="old"></param>
        private void reloadController(InputController old)
        {
            Delegate[] delegates = old.GetButtonPressedMethodsAndUnsubscribe();
            foreach (Delegate del in delegates)
                activeController.ButtonPressed += (del as EventHandler<int>);
        }

        private InputController activeController;
        private List<EHWInput> availableHWInputs = new List<EHWInput>();
        private List<InputController> inputControllers = new List<InputController>();
    }
}