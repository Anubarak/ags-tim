using AGS_Tim.models;
using System;

namespace AGS_Tim.controllers
{
    /// <summary> Interface für den Zugriff auf den Hardware Input </summary>
    public interface InputController
    {
        /// <summary> Das ButtonPressed Event mit der Nummer des Buttons </summary>
        event EventHandler<int> ButtonPressed;

        /// <summary> Event welches bei Verbindung von </summary>
        event EventHandler<EHWInput> Connected;

        /// <summary> Event welches beim Disconnect den nächsten Funktionierenden Controller liefert </summary>
        event EventHandler<EHWInput> Disconnected;

        /// <summary> Gibt an ob der Controller verfügbar ist </summary>
        bool Available { get; }
    }
}