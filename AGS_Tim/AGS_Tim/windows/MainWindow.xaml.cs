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
using System.Windows.Shapes;

namespace AGS_Tim.windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Menu menu;
        private NameEntry nameEntry;
        private Game game;
        private Highscore highscore;
        private InputConverter inputConverter;

        public MainWindow()
        {
            InitializeComponent();

            this.Content = this.getMenu();
        }

        public Menu getMenu()
        {
            if (this.menu == null)
            {
                this.menu = new Menu();
            }

            return this.menu;
        }

        public NameEntry GetNameEntry(bool forceRefresh = false)
        {
            if (forceRefresh || this.nameEntry == null)
            {
                this.nameEntry = new NameEntry();
            }

            return this.nameEntry;
        }

        public Highscore GetHighscore(bool forceRefresh = false)
        {
            if (forceRefresh || this.highscore == null)
            {
                this.highscore = new Highscore();
            }

            return this.highscore;
        }

        public Game GetGame(bool forceRefresh = false)
        {
            if (forceRefresh || this.game == null)
            {
                this.game = new Game();
            }

            return this.game;
        }

        public InputConverter ConvertInput(int ButtonNumber, Action<char> Callback)
        {
            if (this.inputConverter == null)
            {
                this.inputConverter = new InputConverter();
            }

            this.inputConverter.Callback = Callback;
            this.inputConverter.Current = ButtonNumber;
            this.inputConverter.StartTimer(false);

            return this.inputConverter;
        }

        public void ButtonPressed(object sender, int ButtonNumber)
        {
            Action<int> action = new Action<int>(handleButtonPressed);
            this.Dispatcher.Invoke(action, ButtonNumber);
        }

        private void handleButtonPressed(int ButtonNumber)
        {
            if (this.Content.GetType() == typeof(Menu))
            {
                this.menu.ButtonPressed(ButtonNumber);
            }
            else if (this.Content.GetType() == typeof(NameEntry))
            {
                this.nameEntry.ButtonPressed(ButtonNumber);
            }
            else if (this.Content.GetType() == typeof(Game))
            {
                this.game.ButtonPressed(ButtonNumber);
            }
            else if (this.Content.GetType() == typeof(Highscore))
            {
                this.highscore.ButtonPressed(ButtonNumber);
            }
            else
            {
                MessageBox.Show("Fehler");
            }

        }
    }
}
