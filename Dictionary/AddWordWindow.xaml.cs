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
    /// Interaction logic for AddWordWindow.xaml
    /// </summary>
    public partial class AddWordWindow : Window
    {
        public AddWordWindow()
        {
            InitializeComponent();
            DataContext = new CategoryList();
        }

        private bool RequiredFieldsAreFilled()
        {
            if(tbWord.Text.Length == 0) { return false; }
            if(tbDescription.Text.Length == 0) { return false; }
            if(cbCategory.Text.Length == 0) { return false; }
            return true;
        }

        private bool ImageFieldIsFilled()
        {
            return tbImage.Text.Length > 0;
        }

        private void ClearFields()
        {
            tbWord.Clear();
            tbDescription.Clear();
            tbImage.Clear();
            cbCategory.SelectedIndex = -1;
        }
        private void btnAddWord_Click(object sender, RoutedEventArgs e)
        {
            if(!RequiredFieldsAreFilled()) 
            {
                MessageBox.Show("Not all fields are completed");
                return;
            }
            if (ImageFieldIsFilled()) 
            {
                EntryUploader.Upload(tbWord.Text, cbCategory.Text, tbDescription.Text, tbImage.Text);
            }
            else
            {
                EntryUploader.Upload(tbWord.Text, cbCategory.Text, tbDescription.Text);
            }
            if (cbCategory.SelectedIndex <= -1)
            {
                CategoryUploader.Upload(cbCategory.Text);
                cbCategory.Text = string.Empty;
                (DataContext as CategoryList).Categories.Add(cbCategory.Text);
            }
            ClearFields();
        }

        private void cbCategory_KeyUp(object sender, KeyEventArgs e)
        {
            (DataContext as CategoryList).FilterByStartsWith(cbCategory.Text);
            cbCategory.IsDropDownOpen = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdministratorWindow administratorWindow = new AdministratorWindow();
            administratorWindow.Show();
            Close();
        }
    }
}
