using Randomizer.Managers;
using Randomizer.Tools;
using Randomizer.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/eve.jpg", UriKind.Absolute));
            Background = myBrush;
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.StartApplication();
            DataContext = mainWindowViewModel;
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}