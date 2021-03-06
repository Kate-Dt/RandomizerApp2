﻿using Randomizer.Models;
using Randomizer.Tools;
using System;
using System.IO;

namespace Randomizer.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }

        static StationManager()
        {
            DeserializeLastUser();
        }

        private static void DeserializeLastUser()
        {
            User userCandidate;
            try
            {
                userCandidate = SerializationManager.Deserialize<User>(Path.Combine(FileFolderHelper.LastUserFilePath));
            }
            catch (Exception ex)
            {
                userCandidate = null;
                Logger.Log("Failed to Deserialize last user", ex);
            }
            if (userCandidate == null)
            {
                Logger.Log("User was not deserialized");
                return;
            }
            userCandidate = DBManager.CheckCachedUser(userCandidate);
            if (userCandidate == null)
            {
                Logger.Log("Failed to relogin last user");
            }
            else
            {
                CurrentUser = userCandidate;
            }
        }

        public  static void CloseApp()
        {
            Environment.Exit(1);
        }
    }
}
