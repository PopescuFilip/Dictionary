using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class CategoryList : INotifyPropertyChanged
    {
        private ObservableCollection<string> _categories;

        public ObservableCollection<string> Categories
        {
            get { return _categories; }
            set
            {
                if (_categories != value)
                {
                    _categories = value;
                    OnPropertyChanged(nameof(Categories));
                }
            }
        }

        public string SelectedCategory { get; set; }
        public CategoryList()
        {
            Categories = new ObservableCollection<string>(CategoryDownloader.Download());
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void FilterByStartsWith(string prefix)
        {
            Categories = new ObservableCollection<string>(CategoryDownloader.Download().Where(x => x.StartsWith(prefix)));
        }
    }
}
