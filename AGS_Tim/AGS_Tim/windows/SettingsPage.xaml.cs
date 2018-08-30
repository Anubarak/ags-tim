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
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        public void ButtonPressed(int ButtonNumber)
        {
            if (ButtonNumber == 1)
            {
                Main.mainWindow.Content = Main.mainWindow.getMenu();
            }
            else if (ButtonNumber == 2)
            {
                if (this.RbEasy.IsChecked == true)
                {
                    this.RbHard.IsChecked = true;
                }
                else if (RbMedium.IsChecked == true)
                {
                    this.RbEasy.IsChecked = true;
                }
                else
                {
                    this.RbMedium.IsChecked = true;
                }
            }
            else if (ButtonNumber == 8)
            {
                if (this.RbEasy.IsChecked == true)
                {
                    this.RbMedium.IsChecked = true;
                }
                else if (RbMedium.IsChecked == true)
                {
                    this.RbHard.IsChecked = true;
                }
                else
                {
                    this.RbEasy.IsChecked = true;
                }
            }
        }
    }
}
