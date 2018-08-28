using AGS_Tim.models;
using System;
using System.Management;
using System.Threading;
using System.Windows;

namespace AGS_Tim.controllers
{
    public class Numpad : InputController
    {
        /// <summary> Initializes the <see cref="Numpad"/> class and connects the keyboard events from the MainWindow </summary>
        /// <param name="mainWindow"></param>
        public Numpad(Window mainWindow)
        {
            availabilityThread = new Thread(new ThreadStart(checkAvailability));
            availabilityThread.Start();
            mainWindow.KeyDown += MainWindow_KeyDown;
        }

        /// <summary> Behandelt das Drücken einer Taste </summary>
        public event EventHandler<int> ButtonPressed;

        /// <summary> Event welches beim Connect der Hardware feuert </summary>
        public event EventHandler<EHWInput> Connected;

        /// <summary> Event welches beim Disconnect der Harware feuert </summary>
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

        /// <summary> Gibt an ob die Hardware verfügbar ist </summary>
        public bool Available
        {
            get
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select Name from Win32_Keyboard");
                foreach (ManagementObject keyboard in searcher.Get())
                {
                    if (!keyboard.GetPropertyValue("Name").Equals(""))
                        return true;
                }
                return false;
            }
        }

        /// <summary> Type of the InputController </summary>
        public EHWInput hWInputType => EHWInput.Keyboard;

        /// <summary> Methode für Threadaufruf. Prüft alle 5 Sekunden ob die Hardwarekomponente verfügbar ist </summary>
        private void checkAvailability()
        {
            bool oldAvailable = Available;
            while (true)
            {
                if (Available != oldAvailable)
                {
                    if (Available && Connected != null)
                        Connected(this, EHWInput.Keyboard);
                    if (!Available && Disconnected != null)
                        Disconnected(this, EHWInput.Keyboard);
                }
                oldAvailable = Available;
                Thread.Sleep(5000);
            }
        }

        /// <summary> Behandelt das Drücken einer Tastaturtaste, wenn das MainWindow im Fokus ist </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            int numberPressed = 0;
            switch (e.Key)
            {
                case System.Windows.Input.Key.NumPad1:
                    numberPressed = 1;
                    break;

                case System.Windows.Input.Key.NumPad2:
                    numberPressed = 2;
                    break;

                case System.Windows.Input.Key.NumPad3:
                    numberPressed = 3;
                    break;

                case System.Windows.Input.Key.NumPad4:
                    numberPressed = 4;
                    break;

                case System.Windows.Input.Key.NumPad5:
                    numberPressed = 5;
                    break;

                case System.Windows.Input.Key.NumPad6:
                    numberPressed = 6;
                    break;

                case System.Windows.Input.Key.NumPad7:
                    numberPressed = 7;
                    break;

                case System.Windows.Input.Key.NumPad8:
                    numberPressed = 8;
                    break;

                case System.Windows.Input.Key.NumPad9:
                    numberPressed = 9;
                    break;
            }

            if (numberPressed != 0 && ButtonPressed != null)
                ButtonPressed(this, numberPressed);
        }

        private Thread availabilityThread;
    }
}