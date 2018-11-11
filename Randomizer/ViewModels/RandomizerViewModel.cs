using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using JetBrains.Annotations;
using Randomizer.Managers;
using Randomizer.Tools;

namespace Randomizer.ViewModels
{
    class RandomizerViewModel : BaseViewModel
    {
        #region Fields

        private string _fromNumber;
        private string _toNumber;
        private string _result;
        private ObservableCollection<int> _randomSequenceCollection;

        #region Commands
        private ICommand _generateSequenceCommand;
        private ICommand _pastQueriesCommand;

        #endregion
        #endregion

        #region Properties
        public string FromNumber
        {
            get
            {
                return _fromNumber;
            }
            set
            {
                _fromNumber = value;
                OnPropertyChanged();
            }
        }

        public string ToNumber
        {
            get
            {
                return _toNumber;
            }
            set
            {
                _toNumber = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                 OnPropertyChanged("Result");
            }
        }

        public ObservableCollection<int> RandomSequenceCollection
        {
            get { return _randomSequenceCollection; }
        }

        #region Commands

        public ICommand GenerateSequenceCommand
        {
            get
            {
                return _generateSequenceCommand ?? (_generateSequenceCommand = new RelayCommand<object>(GenerateSequenceExecute));
            }
        }
        public ICommand PastQueriesCommand
        {
            get
            {
                return _pastQueriesCommand ?? (_pastQueriesCommand = new RelayCommand<object>(PastQueriesExecute));
            }
        }

        public RandomizerViewModel()
        {
            _result = "";
        }

        //TODO separate thread and add to database

        private void GenerateSequenceExecute(object obj)
        {
            int from = 0;
            int to = 0;
            if (Int32.TryParse(_fromNumber, out from) && Int32.TryParse(_toNumber, out to))
            {
                //TODO add method to swap values
                if (from > to)
                {
                    MessageBox.Show("From (number) should be less than To (number)");
                }
                else
                {
                    _result = "";
                    int randomNumber;
                    int totalQuantity = to - from + 1;
                    _randomSequenceCollection = new ObservableCollection<int>();
                    Random random = new Random();
                    while (totalQuantity > 0)
                    {
                        randomNumber = random.Next(from, to + 1);
                        if (!_randomSequenceCollection.Contains(randomNumber))
                        {
                            _randomSequenceCollection.Add(randomNumber);
                            totalQuantity--;
                        }
                    }
                    foreach (int i in _randomSequenceCollection)
                    {
                        _result += " " + i + "\n";
                    }
                    OnPropertyChanged("Result");
                }
            }
            else
            {
                MessageBox.Show("Error parsing");
            }
        }

        //TODO 
        private bool GenerateSequenceCanExecute(object obj)
        {
            return true;
            //return !String.IsNullOrWhiteSpace(_fromNumber) && !String.IsNullOrWhiteSpace(_toNumber);
        }

        private void PastQueriesExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Archive);
        }

        #endregion
        #endregion
        
    }
}
