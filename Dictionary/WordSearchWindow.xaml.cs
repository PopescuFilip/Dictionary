using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Interaction logic for WordSearchWindow.xaml
    /// </summary>
    public partial class WordSearchWindow : Window
    {
        private bool isAdmin;
        public WordSearchWindow(bool isAdmin = false)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            DataContext = new EntryAndCategoryList();
        }

        private void CbWord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as EntryAndCategoryList).EntryList.SelectedEntry = (sender as ComboBox).SelectedItem as DictionaryEntry;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbWord.SelectedIndex == -1)
            {
                MessageBox.Show("You have not picked a word");
                return;
            }
            ViewEntryWindow viewEntryWindow = new ViewEntryWindow((DataContext as EntryAndCategoryList).EntryList.SelectedEntry, isAdmin);
            viewEntryWindow.Show();
            Close();
        }

        private void cbWord_KeyUp(object sender, KeyEventArgs e)
        {
            if(cbCategory.Text == "")
                (DataContext as EntryAndCategoryList).FilterEntries(cbWord.Text);
            else
                (DataContext as EntryAndCategoryList).FilterEntries(cbWord.Text, cbCategory.Text);
            cbWord.IsDropDownOpen = true;
        }

        private void cbCategory_KeyUp(object sender, KeyEventArgs e)
        {
            (DataContext as EntryAndCategoryList).FilterCategories(cbCategory.Text);
            (DataContext as EntryAndCategoryList).FilterEntries(cbWord.Text, cbCategory.Text);
            cbCategory.IsDropDownOpen = true;
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as EntryAndCategoryList).CategoryList.SelectedCategory = (sender as ComboBox).SelectedItem as string;
            (DataContext as EntryAndCategoryList).FilterEntries(cbWord.Text, cbCategory.SelectedItem as string);
            cbWord.IsDropDownOpen = true;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if(isAdmin) 
            {
                AdministratorWindow administratorWindow = new AdministratorWindow();
                administratorWindow.Show();
                Close();
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }
    }
}
