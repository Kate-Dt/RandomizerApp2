using Randomizer.Managers;
using Randomizer.Tools;
using Randomizer.ViewModels;
using System.Windows.Controls;

namespace Randomizer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.StartApplication();
            DataContext = mainWindowViewModel;
            //navigationModel.Navigate(ModesEnum.SignIn);
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }

}