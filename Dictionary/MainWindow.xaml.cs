using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            WordSearchWindow searchWindow = new WordSearchWindow();
            searchWindow.Show();
            Close();
        }

        private void BtnDivertisment_Click(object sender, RoutedEventArgs e)
        {
            GameWindow divertisment = new GameWindow();
            divertisment.Show();
            Close();
        }
    }
}