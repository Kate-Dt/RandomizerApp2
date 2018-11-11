using Randomizer.ViewModels;

namespace Randomizer.Views
{
    /// <summary>
    /// Логика взаимодействия для ArchiveView.xaml
    /// </summary>
    public partial class ArchiveView
    {
        public ArchiveView()
        {
            InitializeComponent();
            var archiveViewModel = new ArchiveViewModel();
            DataContext = archiveViewModel;
        }
    }
}
