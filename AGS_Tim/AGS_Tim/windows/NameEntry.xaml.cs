using AGS_Tim.services;
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
    /// Interaction logic for NameEntry.xaml
    /// </summary>
    public partial class NameEntry : Page
    {
        public NameEntry()
        {
            InitializeComponent();
        }

        public void ButtonPressed(int ButtonNumber)
        {
            if (ButtonNumber == 1)
            {
                Main.mainWindow.Content = Main.mainWindow.GetGame();
            }
            else
            {
                Action<char> action = new Action<char>(TimerElapsed);
                
                InputConverter inputConverter = Main.mainWindow.ConvertInput(ButtonNumber, action);
                this.BorderCharacter.Visibility = Visibility.Visible;
                this.LblCharacter.Content = inputConverter.GetCharacter();
            }
        }

        public void TimerElapsed(char x)
        {
            this.TbName.Text += x;
            this.LblCharacter.Content = "";
            this.BorderCharacter.Visibility = Visibility.Hidden;
        }
    }
}
