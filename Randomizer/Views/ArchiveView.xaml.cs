using Randomizer.ViewModels;

namespace Randomizer.Views
{
    /// <summary>
    /// Логика взаимодействия для ArchiveView.xaml
    /// </summary>
    public partial class ArchiveView
    {
        public ArchiveView(BaseViewModel viewModel)
        {
            InitializeComponent();
            var archiveViewModel = viewModel ?? new ArchiveViewModel();
            DataContext = archiveViewModel;
        }
    }
}
