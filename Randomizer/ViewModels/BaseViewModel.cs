using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace Randomizer.ViewModels
{
    public class BaseViewModel : Page, INotifyPropertyChanged
    {
        sealed class CallerMemberNameAttribute : Attribute { }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
