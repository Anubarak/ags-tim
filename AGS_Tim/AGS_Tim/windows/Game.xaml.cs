using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
using WpfAnimatedGif;
using AGS_Tim.services;

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
        string answerInput = "";
        
        

        public Game()
        {
            InitializeComponent();
            this.DataContext = this.activePlayer;
        }

        /// <summary>
        /// handles the Button Pressed Event
        /// </summary>
        /// <param name="ButtonNumber"></param>
        public void ButtonPressed(int ButtonNumber)
        {
            if (IsAnswering) // Answering the Question
            {
                Action<char> action = new Action<char>(TimerElapsed);
                InputConverter inputConverter = Main.mainWindow.ConvertInput(ButtonNumber, action);
                this.BorderCharacter.Visibility = Visibility.Visible;
                this.LblCharacter.Content = inputConverter.GetCharacter();
                

            }
            else //Player Selection
            {
                //Confirming Player Selection
                if (ButtonNumber == 1) {


                    //Checks if Player was already Played
                    if (!Main.gameSession.gs.playersCompleted.Contains(Main.gameSession.gs.players[CurrentTable - 1].ID))
                    {
                        this.IsAnswering = true;
                        activePlayer = Main.gameSession.gs.players[CurrentTable - 1];
                        this.TbQuestion.Text = activePlayer.Question.text;
                        this.ImgPlayer.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/" + activePlayer.PlayerPicture));
                        ImageBehavior.SetAnimatedSource(ImgPlayer, ImgPlayer.Source);
                        this.ImgPlayer.Visibility = Visibility.Visible;
                        Main.validate = new Validate(activePlayer);
                    }
                    else
                    {
                        // Hier hin was passieren soll wenn der Player schon gespielt wurde
                    }
                 
                }

                // Selecting player with gamepad
                // UP AND DOWN
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
                //LEFT
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
                //RIGHT
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

        /// <summary>
        /// Sets the border around the selected Player to visible
        /// </summary>
        /// <param name="activate"></param>
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


        /// <summary>
        /// deactivates the Border around the Player
        /// </summary>
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


        /// <summary>
        /// Is Triggered when the Timer of the Input elapsed, Checks if the Answer is correct
        /// </summary>
        /// <param name="x"></param>
        public void TimerElapsed(char x)
        {

            answerInput = answerInput + x;
            if (Main.validate.CheckAnswer(answerInput) == ValidateAnswerResponse.WrongAnswer)
            {
                answerInput = answerInput.Remove(answerInput.Length -1  , 1);

            }
            else if (Main.validate.CheckAnswer(answerInput) == ValidateAnswerResponse.AnswerComplete)
            {
                Main.gameSession.gs.playersCompleted.Add(activePlayer.ID);
                Main.gameSession.gs.playersCompleted.Add(activePlayer.ID);
                Main.gameSession.gs.playersCompleted.Add(activePlayer.ID);
                Main.gameSession.gs.playersCompleted.Add(activePlayer.ID);
                Main.gameSession.gs.playersCompleted.Add(activePlayer.ID);
                Main.gameSession.gs.playersCompleted.Add(activePlayer.ID);

                if (CheckIfGameIsOver())
                {
                    EndGameSession();
                    IsAnswering = false;
                }
                else
                {
                    ResetWindow();
                    IsAnswering = false;

                    TbQuestion.Text = "\n\nDas war die Richtige Antwort!\nWähle den nächsten Schüler den du helfen möchtest!";
                   
                   this.ImgPlayer.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/CheckMark.png"));
                    ImageBehavior.SetAnimatedSource(ImgPlayer, ImgPlayer.Source);
                    this.ImgPlayer.Visibility = Visibility.Visible;

                }
              
            }
            else if (Main.validate.CheckAnswer(answerInput) == ValidateAnswerResponse.CorrectAnswer)
            {
                Main.gameSession.gs.wrongAnswerCounter += 1; 
            }


            this.TbAnswer.Text = answerInput;
            this.LblCharacter.Content = "";
            this.BorderCharacter.Visibility = Visibility.Hidden;
        }


        /// <summary>
        /// Cheks if all 6 Players have been played
        /// </summary>
        /// <returns></returns>
        private bool CheckIfGameIsOver()
        {
        
            if (Main.gameSession.gs.playersCompleted.Count() >= 6)
            

                return true;
    
            else
                
            return false;
        }

        /// <summary>
        /// Handles what happens when a gamesession ends,  Writes Highscore to database
        /// </summary>
        private void EndGameSession()
        {
            Main.gameSession.gs.endTime = DateTime.Now;
            ResetWindow();
            Main.highscores.WriteHighscore();

            TbQuestion.Text = "Herzlichen Glückwunsch!\nDu hast alle Aufgaben gelöst! Du kann das Nachsitzen verlassen.\n\nZurück zum Hauptmenü mit 1\nBeenden mit 2";
            TbQuestion.Text += "\nZeit = " + Main.gameSession.gs.endTime.Subtract(Main.gameSession.gs.startTime).ToString("mm':'ss");
            TbQuestion.Text += "\nPunkte = " + Main.highscores.GetPoints();

            this.ImgPlayer.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/Trophy.png"));
            ImageBehavior.SetAnimatedSource(ImgPlayer, ImgPlayer.Source);
            this.ImgPlayer.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// Resetts the Window Controls used in Answering Questions
        /// </summary>
        private void ResetWindow()
        {
            TbAnswer.Text = "";
            TbQuestion.Text = "";
            answerInput = "";
            this.ImgPlayer.Visibility = Visibility.Hidden;
            this.ImgPlayer.Source = null;
            ImageBehavior.SetAnimatedSource(ImgPlayer, null);
        }
    }
}
