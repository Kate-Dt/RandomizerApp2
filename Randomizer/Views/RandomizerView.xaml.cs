using Randomizer.ViewModels;

namespace Randomizer.Views
{
    /// <summary>
    /// Логика взаимодействия для RandomizerView.xaml
    /// </summary>
    public partial class RandomizerView 
    {
        public RandomizerView()
        {
            InitializeComponent();
            var randomizerViewModel = new RandomizerViewModel();
            DataContext = randomizerViewModel;
        }
    }
}
