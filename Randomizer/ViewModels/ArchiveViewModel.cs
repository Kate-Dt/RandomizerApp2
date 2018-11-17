using JetBrains.Annotations;
using Randomizer.Managers;
using Randomizer.Models;
using Randomizer.Tools;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Randomizer.ViewModels
{
    class ArchiveViewModel : BaseViewModel
    {
        #region  Fields
        public static ObservableCollection<Query> _pastQueriesCollection;

        #region Commands

        private ICommand _backToRandomizerCommand;
        private ICommand _logOutCommand;

        #endregion
        #endregion

        public ObservableCollection<Query> Queries
        {
            get { return _pastQueriesCollection; }
        }

        public ICommand BackToRandomizerCommand
        {
            get
            {
                return _backToRandomizerCommand ?? (_backToRandomizerCommand = new RelayCommand<object>(BackToRandomizerExecute));
            }
        }

        public ICommand LogOutCommand
        {
            get
            {
                return _logOutCommand ?? (_logOutCommand = new RelayCommand<object>(LogOutExecute));
            }
        }

        private void BackToRandomizerExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Randomizer);
        }

        private async void LogOutExecute(object obj)
        {
                LoaderManager.Instance.ShowLoader();
                var result = await Task.Run(() =>
                {
                    try
                    {                        
                        DBManager.SerializeCurrent(StationManager.CurrentUser);
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
                    NavigationManager.Instance.Navigate(ModesEnum.SignIn); 
            }
        }

        public ArchiveViewModel()
        {
            FillQueries();
        }

        public void FillQueries()
        {
            if (StationManager.CurrentUser.Queries == null)
            {
                return;
            }
            _pastQueriesCollection = new ObservableCollection<Query>();
            foreach (var query in StationManager.CurrentUser.Queries)
            {
                _pastQueriesCollection.Add(query);
                //OnPropertyChanged("Queries");
            }
        }
        
    }
}
