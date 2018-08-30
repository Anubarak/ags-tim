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
    /// Interaction logic for Highscore.xaml
    /// </summary>
    public partial class Highscore : Page
    {
        public Highscore()
        {
            InitializeComponent();

            int Id = 1;

            DataGridTextColumn colId = new DataGridTextColumn();
            DataGridTextColumn colPoints = new DataGridTextColumn();
            DataGridTextColumn colTime = new DataGridTextColumn();
            DataGridTextColumn colName = new DataGridTextColumn();

            DgHighscore.Columns.Add(colId);
        
            DgHighscore.Columns.Add(colPoints);
            DgHighscore.Columns.Add(colTime);
            DgHighscore.Columns.Add(colName);

           

            colPoints.Binding = new Binding("points");
            colTime.Binding = new Binding("timer");
            colName.Binding = new Binding("name");
            colId.Binding = new Binding("position");

            colId.Header = "Platzierung";
            colPoints.Header = "Punkte";
            colTime.Header = "Zeit";
            colName.Header = "Name";
            

            foreach(var hs in Main.highscores.ReadHighscores())
            {
                hs.position = Id;
                Id++;
                DgHighscore.Items.Add(hs);
            }
            
        }
        
        public void ButtonPressed(int ButtonNumber)
        {
            if (ButtonNumber == 1)
            {
                Main.mainWindow.Content = Main.mainWindow.getMenu();
            }
        }
    }
}
