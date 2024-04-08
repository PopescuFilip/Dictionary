using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Game : INotifyPropertyChanged
    {
        public enum Clue
        {
            Description,
            Image
        }
        private const int DefaultNoOfRounds = 5;
        private ObservableCollection<DictionaryEntry> _words;
        private List<string> _guessedWords;
        private List<bool> _guessedTracker;
        private List<Clue> _clues;
        
        private DictionaryEntry _currentWord;
        public DictionaryEntry CurrentWord
        {
            get { return _currentWord; }
            set
            {
                if (_currentWord != value)
                {
                    _currentWord = value;
                    OnPropertyChanged(nameof(CurrentWord));
                }
            }
        }

        private int _currentRound;
        public int CurrentRound
        {
            get { return _currentRound; }
            set 
            {
                if (value > _words.Count)
                    return;
                _currentRound = value;
                CurrentWord = _words[value];
                OnPropertyChanged(nameof(CurrentGuessedWord));
            }
        }
        public Clue CurrentClue
        {
            get
            {
                return _clues[_currentRound];
            }
        }

        public string CurrentGuessedWord
        {
            get
            {
                return _guessedWords[_currentRound];
            }
            set
            {
                _guessedWords[_currentRound] = value;
                OnPropertyChanged(nameof(CurrentGuessedWord));
            }
        }
        public int NoOfRounds
        {
            get
            {
                return _words.Count;
            }
        }

        public Game(int noOfRounds = DefaultNoOfRounds) 
        {
            _words = new ObservableCollection<DictionaryEntry>();
            _guessedTracker = new List<bool>();
            _guessedWords = new List<string>();
            _clues = new List<Clue>();
            FillLists(noOfRounds);
        }

        private void FillLists(int noOfRounds)
        {
            FillWords(noOfRounds);
            FillGuessedTracker(noOfRounds);
            FillClues(noOfRounds);
            FillGuessedWords(noOfRounds);
        }
        private void FillWords(int noOfRounds)
        {
            List<DictionaryEntry> list = EntryDownloader.Download();
            Random random = new Random();
            for (int i = 0; i < noOfRounds; i++)
            {
                int randomIndex = random.Next(list.Count);
                _words.Add(list[randomIndex]);
            }
        }

        private void FillGuessedTracker(int noOfRounds)
        {
            for (int i = 0; i < noOfRounds; i++)
            {
                _guessedTracker.Add(false);
            }
        }

        private void FillClues(int noOfRounds)
        {
            Random random = new Random();
            for (int i = 0; i < noOfRounds; i++)
            {
                if (random.Next(2) == 0)
                    _clues.Add(Clue.Description);
                else
                    _clues.Add(Clue.Image);
            }
        }

        private void FillGuessedWords(int noOfRounds)
        {
            for(int i = 0;i < noOfRounds;i++)
            {
                _guessedWords.Add(String.Empty);
            }
        }
        public int GetScore()
        {
            int score = 0;
            for (int i = 0; i < _words.Count; i++)
            {
                if (_guessedWords[i] == _words[i].Word)
                    score++;
            }
            return score;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
