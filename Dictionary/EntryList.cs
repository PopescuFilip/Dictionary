using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class EntryList : INotifyPropertyChanged
    {
        private ObservableCollection<DictionaryEntry> _entries;
        public ObservableCollection<DictionaryEntry> Entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged(nameof(Entries));
            }
        }
        public DictionaryEntry SelectedEntry { get; set; }
        public EntryList() 
        {
            Entries = new ObservableCollection<DictionaryEntry>(EntryDownloader.Download());
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void FilterByStartsWith(string prefix)
        {
            Entries = new ObservableCollection<DictionaryEntry>(EntryDownloader.Download().Where(x => x.Word.StartsWith(prefix)));
        }

        public void FilterByCategory(string category) 
        {
            Entries = new ObservableCollection<DictionaryEntry>(EntryDownloader.Download().Where(x => x.Category == category));
        }

        public void Filter(string prefix, string category) 
        {
            Entries = new ObservableCollection<DictionaryEntry>(
                EntryDownloader.Download().Where(x => x.Word.StartsWith(prefix) && x.Category == category)
                );
        }
    }
}
