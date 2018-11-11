using Randomizer.Managers;
using Randomizer.Models;
using Randomizer.Tools;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Randomizer.ViewModels
{
    class ArchiveViewModel : BaseViewModel
    {
        #region  Fields
        private ObservableCollection<Query> _pastQueriesCollection;

        #region Commands

        private ICommand _backToRandomizerCommand;

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

        private void BackToRandomizerExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Randomizer);
        }

        public ArchiveViewModel()
        {
            //FillQueries();
        }

        private void FillQueries()
        {
            _pastQueriesCollection = new ObservableCollection<Query>();
            foreach (var query in StationManager.CurrentUser.Queries)
            {
                _pastQueriesCollection.Add(query);
            }
        }
    }
}
