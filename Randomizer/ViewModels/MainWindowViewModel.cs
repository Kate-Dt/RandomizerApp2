using Randomizer.Managers;
using Randomizer.Tools;
using System.Windows;

namespace Randomizer.ViewModels
{
    public class MainWindowViewModel : BaseViewModel, ILoaderOwner
    {
        private Visibility _visibility = Visibility.Hidden;
        private bool _isEnabled = true;

        public Visibility LoaderVisibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }

        internal void StartApplication()
        {
            NavigationManager.Instance.Navigate(StationManager.CurrentUser != null ? ModesEnum.Randomizer : ModesEnum.SignIn);
        }
    }
}