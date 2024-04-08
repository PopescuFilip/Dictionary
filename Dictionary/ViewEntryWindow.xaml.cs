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
    /// Interaction logic for ViewEntryWindow.xaml
    /// </summary>
    public partial class ViewEntryWindow : Window
    {
        public ViewEntryWindow(object entry, bool isAdmin = false)
        {
            InitializeComponent();
            SetWindowProperties(isAdmin);
            DataContext = entry;
            if (isAdmin)
            {
                EntryUploader.UploadAllButOne(entry as DictionaryEntry);
            }
        }

        public void SetWindowProperties(bool isAdmin)
        {
            tbWord.Focusable = isAdmin;
            tbCategory.Focusable = isAdmin;
            tbDescription.Focusable = isAdmin;
            tbImage.Focusable = isAdmin;
            btnSave.Visibility = isAdmin ? Visibility.Visible: Visibility.Hidden;
            btnDelete.Visibility = isAdmin ? Visibility.Visible: Visibility.Hidden;
            btnBack.Visibility = isAdmin ? Visibility.Hidden : Visibility.Visible;
        }

        private void ShowAdminWordSearchWindow()
        {
            WordSearchWindow wordSearchWindow = new WordSearchWindow(true);
            wordSearchWindow.Show();
            Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EntryUploader.Upload(DataContext as DictionaryEntry);
            ShowAdminWordSearchWindow();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ShowAdminWordSearchWindow();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            WordSearchWindow wordSearchWindow = new WordSearchWindow();
            wordSearchWindow.Show();
            Close();
        }
    }
}
