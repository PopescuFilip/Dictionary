using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class EntryAndCategoryList : INotifyPropertyChanged
    {
        private EntryList _entryList;
        public EntryList EntryList
        {
            get { return _entryList; }
            set
            {
                if (_entryList != value)
                {
                    _entryList = value;
                    OnPropertyChanged(nameof(EntryList));
                }
            }
        }

        private CategoryList _categoryList;
        public CategoryList CategoryList
        {
            get { return _categoryList; }
            set
            {
                if (_categoryList != value)
                {
                    _categoryList = value;
                    OnPropertyChanged(nameof(CategoryList));
                }
            }
        }
        public EntryAndCategoryList() 
        {
            EntryList = new EntryList();
            CategoryList = new CategoryList();
        }

        public void FilterCategories(string prefix)
        {
            CategoryList.FilterByStartsWith(prefix);
        }
        public void FilterEntries(string prefix, string category)
        {
            EntryList.Filter(prefix, category);
        }

        public void FilterEntries(string prefix)
        {
            EntryList.FilterByStartsWith(prefix);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
