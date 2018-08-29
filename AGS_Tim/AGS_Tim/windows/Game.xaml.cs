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
using AGS_Tim.models;
namespace AGS_Tim.windows
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        bool IsAnswering = false;
        int CurrentTable = 1;
        Player activePlayer;
        

        public Game()
        {
            InitializeComponent();
            this.DataContext = this.activePlayer;
        }

        public void ButtonPressed(int ButtonNumber)
        {
            if (IsAnswering)
            {
                
            }
            else
            {
                if (ButtonNumber == 1) {
                    this.IsAnswering = true;

                    activePlayer =  Main.gameSession.gs.players[CurrentTable - 1];
                    //this.TbQuestion.Text = activePlayer.Question.text;

                }
                else if (ButtonNumber == 2 || ButtonNumber == 8)
                {
                    switch (CurrentTable)
                    {
                        case 1:
                            ChangeTable(4);
                            break;
                        case 2:
                            ChangeTable(5);
                            break;
                        case 3:
                            ChangeTable(6);
                            break;
                        case 4:
                            ChangeTable(1);
                            break;
                        case 5:
                            ChangeTable(2);
                            break;
                        case 6:
                            ChangeTable(3);
                            break;
                    }
                }
                else if (ButtonNumber == 4)
                {
                    switch (CurrentTable)
                    {
                        case 1:
                            ChangeTable(3);
                            break;
                        case 2:
                            ChangeTable(1);
                            break;
                        case 3:
                            ChangeTable(2);
                            break;
                        case 4:
                            ChangeTable(6);
                            break;
                        case 5:
                            ChangeTable(4);
                            break;
                        case 6:
                            ChangeTable(5);
                            break;
                    }
                }
                else if (ButtonNumber == 6)
                {
                    switch (CurrentTable)
                    {
                        case 1:
                            ChangeTable(2);
                            break;
                        case 2:
                            ChangeTable(3);
                            break;
                        case 3:
                            ChangeTable(1);
                            break;
                        case 4:
                            ChangeTable(5);
                            break;
                        case 5:
                            ChangeTable(6);
                            break;
                        case 6:
                            ChangeTable(4);
                            break;
                    }
                }
            }
        }

        private void ChangeTable(int activate)
        {
            DeactivateTable();
            this.CurrentTable = activate;
            switch (activate)
            {
                case 1:
                    this.BorderTable1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    this.BorderTable2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    this.BorderTable3.Visibility = Visibility.Visible;
                    break;
                case 4:
                    this.BorderTable4.Visibility = Visibility.Visible;
                    break;
                case 5:
                    this.BorderTable5.Visibility = Visibility.Visible;
                    break;
                case 6:
                    this.BorderTable6.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void DeactivateTable()
        {
            this.BorderTable1.Visibility = Visibility.Hidden;
            this.BorderTable2.Visibility = Visibility.Hidden;
            this.BorderTable3.Visibility = Visibility.Hidden;
            this.BorderTable5.Visibility = Visibility.Hidden;
            this.BorderTable4.Visibility = Visibility.Hidden;
            this.BorderTable6.Visibility = Visibility.Hidden;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Main.gameSession.gs.startTime = DateTime.Now;

            this.BorderTable1.Visibility = Visibility.Visible;
        }
    }
}
