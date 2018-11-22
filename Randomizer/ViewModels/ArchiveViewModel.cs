using Randomizer.Managers;
using Randomizer.Models;
using Randomizer.Tools;
using System;
using System.Collections.ObjectModel;
using System.IO;
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

        #endregion
        #endregion

        public ObservableCollection<Query> Queries
        {
            get { return _pastQueriesCollection; }
            set { _pastQueriesCollection = value; }
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
            _pastQueriesCollection = new ObservableCollection<Query>();
            Update();
         }

        internal new void Update()
        {
            if (StationManager.CurrentUser.Queries == null)
            {
                return;
            }
            _pastQueriesCollection.Clear();
            foreach (var query in StationManager.CurrentUser.Queries)
            {
                _pastQueriesCollection.Add(query);
            }
        }        
    }
}
