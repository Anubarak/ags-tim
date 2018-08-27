using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AGS_Tim
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {

        private void StartUp(object sender, StartupEventArgs e)
        {
            AGS_Tim.Main.init();

            var wMain = new MainWindow();
            wMain.ShowDialog();
        }

    }
}
