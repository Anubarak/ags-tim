using AGS_Tim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AGS_Tim.windows
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }
        
        public void ButtonPressed(int ButtonNumber)
        {
            switch (ButtonNumber)
            {
                case 1:
                    Main.mainWindow.Content = Main.mainWindow.GetNameEntry();
                    break;
                case 2:
                    Main.mainWindow.Content = Main.mainWindow.GetHighscore();
                    break;
                case 3:
                    //Main.mainWindow.Content = Main.mainWindow.GetSettingsPage();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
