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

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for Divertisment.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public int roundNumber;
        public GameWindow()
        {
            roundNumber = -1;
            InitializeComponent();
            DataContext = new Game();
        }
        private void UpdateWindow()
        {
            (DataContext as Game).CurrentRound = roundNumber;
            btnNext.Visibility = roundNumber == (DataContext as Game).NoOfRounds - 1 ? Visibility.Hidden : Visibility.Visible;
            btnFinish.Visibility = roundNumber == (DataContext as Game).NoOfRounds - 1 ? Visibility.Visible : Visibility.Hidden;
            btnPrevious.Visibility = roundNumber == 0 ? Visibility.Hidden : Visibility.Visible;
            if ((DataContext as Game).CurrentClue == Game.Clue.Description)
            {
                tbDescription.Visibility = Visibility.Visible;
                image.Visibility = Visibility.Hidden;
            }
            else
            {
                tbDescription.Visibility= Visibility.Hidden;
                image.Visibility = Visibility.Visible;
            }
        }
        private void InitGameWindow()
        {
            btnStart.Visibility = Visibility.Hidden;
            labelWord.Visibility = Visibility.Visible;
            tbWord.Visibility = Visibility.Visible;
            btnNext.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            roundNumber++;
            InitGameWindow();
            UpdateWindow();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            roundNumber++;
            UpdateWindow();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            roundNumber--;
            UpdateWindow();
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            int score = (DataContext as Game).GetScore();
            EndScreenWindow endScreenWindow = new EndScreenWindow(score);
            endScreenWindow.Show();
            Close();
        }
    }
}
