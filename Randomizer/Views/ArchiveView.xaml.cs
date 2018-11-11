using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using  Randomizer.ViewModels;

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
