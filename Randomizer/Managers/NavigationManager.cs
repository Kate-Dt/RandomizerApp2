﻿using Randomizer.Tools;
using Randomizer.ViewModels;

namespace Randomizer.Managers
{
    internal class NavigationManager
    {
        #region static
        /// <summary>
        /// This field is used only in lock to synchronize threads
        /// </summary>
        private static readonly object Lock = new object();
        /// <summary>
        /// Singleton Object of a manager
        /// </summary>
        private static NavigationManager _instance;

        /// <summary>
        /// Singleton Object of a manager
        /// </summary>
        public static NavigationManager Instance
        {
            get
            {
                //If object is already initialized, then return it
                if (_instance != null)
                    return _instance;
                //Lock operator for threads synchrnization, in case few threads 
                //will try to initialize Instance at the same time
                lock (Lock)
                {
                    //Initialize Singleton instance and return its object
                    return _instance = new NavigationManager();
                }
            }
        }
        #endregion

        private NavigationModel _navigationModel;
        /// <summary>
        /// This method is used to switch to another navigation model
        /// </summary>
        /// <param name="navigationModel">New NavigationModel</param>
        internal void Initialize(NavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }
        /// <summary>
        /// This method performs switch between different controls
        /// </summary>
        /// <param name="mode">Enum value of corresponding control</param>
        internal void Navigate(ModesEnum mode, BaseViewModel model = null)
        {
            //If _navigationModel is null, nothing will happen
            _navigationModel?.Navigate(mode, model);
        }

        internal void NullifyViewModels()
        {
            _navigationModel.NullifyViewModels();
        }
    }
}
