using Randomizer.Managers;
using Randomizer.Models;
using Randomizer.Tools;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Randomizer.ViewModels
{
    class RandomizerViewModel : BaseViewModel
    {
        #region Fields

        private string _fromNumber;
        private string _toNumber;
        private string _result;
        private ArchiveViewModel _archiveViewModel;
        private ObservableCollection<int> _randomSequenceCollection;

        #region Commands
        private ICommand _generateSequenceCommand;
        private ICommand _pastQueriesCommand;
        private ICommand _logOutCommand;
        private ICommand _closeCommand;

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
        public ICommand LogOutCommand
        {
            get
            {
                return _logOutCommand ?? (_logOutCommand = new RelayCommand<object>(LogOutExecute));
            }
        }
        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
            }
        }
        
        public RandomizerViewModel()
        {
            _result = string.Empty;
            _archiveViewModel = new ArchiveViewModel();
        }
        
        private async void GenerateSequenceExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                int from = 0;
                int to = 0;
                if (Int32.TryParse(_fromNumber, out from) && Int32.TryParse(_toNumber, out to))
                {
                    if (from > to)
                    {
                        MessageBox.Show("From (number) should be less than To (number)");
                    }
                    else
                    {
                        _result = string.Empty;
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
                        Query currentQuery = new Models.Query(from, to, StationManager.CurrentUser);
                        DBManager.AddQuery(currentQuery);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter correct numbers");
                }
            });
            LoaderManager.Instance.HideLoader();
        }

        private async void LogOutExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    StationManager.CurrentUser = null;
                    FileInfo file = new FileInfo(FileFolderHelper.LastUserFilePath);
                    file.Delete();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sorry, log out failed :(");
                    Logger.Log($"Failed to log out: ", ex);
                    return false;
                }
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                NavigationManager.Instance.NullifyViewModels();
                NavigationManager.Instance.Navigate(ModesEnum.SignIn);
            }
        }

        private void CloseExecute(object obj)
        {
            StationManager.CloseApp();
        }
      
        private void PastQueriesExecute(object obj)
        {
            _archiveViewModel.Update();
            NavigationManager.Instance.Navigate(ModesEnum.Archive, _archiveViewModel);
        }

        #endregion
        #endregion
        
    }
}
