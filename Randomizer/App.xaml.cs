using System;
using System.Windows;
using Randomizer.Managers;

namespace Randomizer
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
             base.OnStartup(e);
             StationManager.Initialize();
            //this.StartupUri = new Uri("/Views/SIgnInView.xaml",
             //   UriKind.Relative);
        }
    }
}
