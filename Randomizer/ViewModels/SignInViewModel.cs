using Randomizer.Managers;
using Randomizer.Models;
using Randomizer.Tools;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Randomizer.ViewModels
{
    internal class SignInViewModel : BaseViewModel
        {
        
        #region  Fields
          private string _login;
          private string _password;

        #region Commands
            private ICommand _closeCommand;
            private ICommand _signInCommand;
            private ICommand _signUpCommand;

        #endregion
        #endregion

            internal SignInViewModel()
            {
            }

        #region Properties

        public string Password
            {
                get { return _password; }
                set { _password = value; }
            }

            public string Login
            {
                get { return _login; }
                set { _login = value; }
            }
        #endregion

            public ICommand CloseCommand
            {
                get
                {
                    return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
                }
            }

            public ICommand SignInCommand
            {
                get
                {
                    return _signInCommand ?? (_signInCommand = new RelayCommand<object>(SignInExecute, SignInCanExecute));
                }
            }

            public ICommand SignUpCommand
            {
                get
                {
                    return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute));
                }
        }
        
            private async void SignInExecute(object obj)
            {
                LoaderManager.Instance.ShowLoader();
                var result = await Task.Run (() =>
                {
                    User currentUser;
                    try
                    {
                        currentUser = DBManager.GetUserByLogin(_login);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to get user" + ex.ToString());
                        Logger.Log("Failed to get user ", ex);
                        return false;
                    }
                    if (currentUser == null)
                    {
                        MessageBox.Show("User doesn't exist");
                        return false;
                    }
                    try
                    {
                        if (!currentUser.CheckPassword(_password))
                        {
                            MessageBox.Show("Wrong password");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid password");
                        Logger.Log($"User failed to enter valid password {ex}", ex);
                        return false;
                    }
                    StationManager.CurrentUser = currentUser;
                    SerializationManager.Serialize(StationManager.CurrentUser, FileFolderHelper.LastUserFilePath);
                    return true;
                });
                LoaderManager.Instance.HideLoader();
                if (result)
                NavigationManager.Instance.Navigate(ModesEnum.Randomizer);
        }

            private bool SignInCanExecute(object obj)
            {
                return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password);
            }

        private void SignUpExecute(object obj)
            {
                NavigationManager.Instance.Navigate(ModesEnum.SignUp);
            }

        private void CloseExecute(object obj)
            {
                Environment.Exit(0);
            }
        }
    }