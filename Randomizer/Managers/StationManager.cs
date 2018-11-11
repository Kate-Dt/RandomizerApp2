using Randomizer.Models;
using System;
using System.Windows;

namespace Randomizer.Managers
{
    public static class StationManager
    {

        public static User CurrentUser { get; set; }

        public static void Initialize()
        {
        }

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
