using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Randomizer.Views;
using Randomizer.Managers;

namespace Randomizer.Tools
{

    internal enum ModesEnum
    {
        SignIn,
        SignUp,
        Randomizer,
        Archive
    }

    internal class NavigationModel
    {
        private readonly IContentWindow _contentWindow;
        private SignInView _signInView;
        private SignUpView _signUpView;
        private RandomizerView _randomizerView;
        private ArchiveView _archiveView;

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.Randomizer:
                    _contentWindow.ContentControl.Content = _randomizerView ?? (_randomizerView = new RandomizerView());
                    break;
                case ModesEnum.SignIn:
                    _contentWindow.ContentControl.Content = _signInView ?? (_signInView = new SignInView());
                    break;
               case ModesEnum.SignUp:
                _contentWindow.ContentControl.Content = _signUpView ?? (_signUpView = new SignUpView());
                break;
                case ModesEnum.Archive:
                    _contentWindow.ContentControl.Content = _archiveView ?? (_archiveView = new ArchiveView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
      }
}
