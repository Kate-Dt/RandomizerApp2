using Randomizer.Managers;
using Randomizer.Models;
using Randomizer.Tools;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Randomizer.ViewModels
{
    class ArchiveViewModel : BaseViewModel
    {
        #region  Fields
        public static ObservableCollection<Query> PastQueriesCollection;

        #region Commands
        private ICommand _backToRandomizerCommand;

        #endregion
        #endregion

        public ObservableCollection<Query> Queries
        {
            get { return PastQueriesCollection; }
            set { PastQueriesCollection = value; }
        }

        public ICommand BackToRandomizerCommand
        {
            get
            {
                return _backToRandomizerCommand ?? (_backToRandomizerCommand = new RelayCommand<object>(BackToRandomizerExecute));
            }
        }
        
        private void BackToRandomizerExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Randomizer);
        }
        
        public ArchiveViewModel()
        {
            PastQueriesCollection = new ObservableCollection<Query>();
            Update();
         }

        internal void Update()
        {
            if (StationManager.CurrentUser.Queries == null)
            {
                MessageBox.Show("Archive is empty!");
                return;
            }
            PastQueriesCollection.Clear();
            foreach (var query in StationManager.CurrentUser.Queries)
            {
                PastQueriesCollection.Add(query);
            }
        }
    }
}
