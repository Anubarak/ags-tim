using AGS_Tim.models;
using System;
using System.Management;
using System.Threading;

namespace AGS_Tim.controllers
{
    public class Numpad : InputController
    {
        public Numpad()
        {
            
        }

        /// <summary> Methode für Threadaufruf. Prüft ob die Hardwarekomponente verfügbar ist </summary>
        private void checkAvailability()
        {
            bool oldAvailable = Available;
            while(true)
            {
                if (Available != oldAvailable)
                {
                    if (Disconnected != null)
                        Disconnected(this, EHWInput.Keyboard);
                }
            }
        }

        public event EventHandler<int> ButtonPressed;

        /// <summary> Event welches beim Disconnect der Harware feuert </summary>
        public event EventHandler<EHWInput> Disconnected;
        public event EventHandler<EHWInput> Connected;

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

        Thread availabilityThread;
    }
}