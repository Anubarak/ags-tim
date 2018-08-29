using AGS_Tim.models;
using SlimDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            hopscotchThread = new Thread(new ThreadStart(callingHopscotchMat));
            if (devices.Count != 0)
            {
                hopscotchMatInstance = devices[0];
                hopscotchMat = new Joystick(input, hopscotchMatInstance.InstanceGuid);
                // wird angeblich benötigt für die Zugriffsart, braucht aber ein Control handle --> für Background sinnvoll?
                //hopscotchMat.SetCooperativeLevel();
                hopscotchMat.Acquire();
                hopscotchThread.Start();
            }
            availabillityThread = new Thread(new ThreadStart(checkAvailability));
            availabillityThread.Start();
        }

        public event EventHandler<int> ButtonPressed;

        public event EventHandler<EHWInput> Connected;

        public event EventHandler<EHWInput> Disconnected;

        /// <summary> Unsubscribes all handler on the <see cref="ButtonPressed"/> event and returns them. </summary>
        /// <returns></returns>
        public Delegate[] GetButtonPressedMethodsAndUnsubscribe()
        {
            Delegate[] delegates = ButtonPressed.GetInvocationList();
            foreach (Delegate del in delegates)
                ButtonPressed -= (del as EventHandler<int>);
            return delegates;
        }

        /// <summary> Shows that the controller is available </summary>
        public bool Available { get { return hopscotchMat != null; } }

        public EHWInput hWInputType => EHWInput.HopScotch;


        /// <summary> loop for catching input </summary>
        private void callingHopscotchMat()
        {
            JoystickState cState = new JoystickState();
            int pressedButton = 0;
            while (Available)
            {
                try
                {
                    hopscotchMat.GetCurrentState(ref cState);
                    bool[] buttonStates = cState.GetButtons();
                    List<int> pressedList = new List<int>();
                    for (int i = 0; i < buttonStates.Count(); i++)
                    {
                        if (buttonStates[i])
                        {
                            int j = 0;
                            switch (i + 1)
                            {
                                case 7:
                                    j = 1;
                                    break;

                                case 8:
                                    j = 2;
                                    break;

                                case 10:
                                    j = 3;
                                    break;

                                case 4:
                                    j = 4;
                                    break;

                                case 5:
                                    j = 5;
                                    break;

                                case 6:
                                    j = 6;
                                    break;

                                case 1:
                                    j = 7;
                                    break;

                                case 2:
                                    j = 8;
                                    break;

                                case 3:
                                    j = 9;
                                    break;

                                default:

                                    continue;
                            }
                            pressedList.Add(j);
                            break;
                        }
                    }
                    if (pressedList.Count != 0 && pressedButton != pressedList[0] && ButtonPressed != null)
                    {
                        ButtonPressed(this, pressedList[0]);
                        pressedButton = pressedList[0];
                    }
                    else
                        pressedButton = 0;
                }
                catch (Exception ex)
                {
                    // throwing for future implementation use
                    throw ex;
                }
                Thread.Sleep(50);
            }
        }

        /// <summary> Methode für Threadaufruf. Prüft alle 5 Sekunden ob die Hardwarekomponente vorhanden ist. </summary>
        private void checkAvailability()
        {
            bool oldAvailable = Available;
            while (true)
            {
                DirectInput input = new DirectInput();
                var devices = input.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AttachedOnly);
                if (devices.Count == 0)
                    available = false;
                else available = true;

                if (hopscotchMatInstance != null && devices.Any(x => x.InstanceGuid == hopscotchMatInstance.InstanceGuid))
                {
                    Thread.Sleep(1000);
                    continue;
                }

                if (available)
                {
                    hopscotchMatInstance = devices[0];
                    hopscotchMat = new Joystick(input, hopscotchMatInstance.InstanceGuid);
                    hopscotchMat.Acquire();
                }

                if (available != oldAvailable)
                {
                    if (available && Connected != null)
                    {
                        Connected(this, EHWInput.HopScotch);
                        if (hopscotchThread.IsAlive == false)
                            hopscotchThread.Start();
                    }
                    if (!available && Disconnected != null)
                    {
                        Disconnected(this, EHWInput.HopScotch);
                        if (hopscotchThread.IsAlive)
                            hopscotchThread.Abort();
                    }
                }

                oldAvailable = available;
                Thread.Sleep(1000);
            }
        }

        private bool available = false;
        private DeviceInstance hopscotchMatInstance;
        private volatile Joystick hopscotchMat;
        private Thread hopscotchThread;
        private Thread availabillityThread;
    }
}