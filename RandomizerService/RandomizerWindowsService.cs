using Randomizer.Tools;
using System;
using System.ServiceModel;
using System.ServiceProcess;

namespace Randomizer.RandomizerService
{
    public class RandomizerWindowsService : ServiceBase
    {
        internal const string CurrentServiceName = "RandomizerService1";
        internal const string CurrentServiceDisplayName = "Randomizer Service1";
        internal const string CurrentServiceSource = "RandomizerServiceSource1";
        internal const string CurrentServiceLogName = "RandomizerServiceLogName1";
        internal const string CurrentServiceDescription = "Randomizer for learning purposes1.";
        private ServiceHost _serviceHost = null;

        public RandomizerWindowsService()
        {
            ServiceName = CurrentServiceName;
            try
            {
                AppDomain.CurrentDomain.UnhandledException += UnhandledException;
                Logger.Log("Initialization");
            }
            catch (Exception ex)
            {
                Logger.Log("Initialization", ex);
            }
        }

        protected override void OnStart(string[] args)
        {
            Logger.Log("OnStart");
            RequestAdditionalTime(120 * 1000);
            try
            {
                if (_serviceHost != null)
                    _serviceHost.Close();
            }
            catch
            {
            }
            try
            {
                _serviceHost = new ServiceHost(typeof(RandomizerService));
                _serviceHost.Open();
            }
            catch (Exception ex)
            {
                Logger.Log("OnStart", ex);
                throw;
            }
            Logger.Log("Service Started");
        }

        protected override void OnStop()
        {
            Logger.Log("OnStop");
            RequestAdditionalTime(120 * 1000);
            try
            {
                _serviceHost.Close();
            }
            catch (Exception ex)
            {
                Logger.Log("Trying To Stop The Host Listener", ex);
            }
            Logger.Log("Service Stopped");
        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (Exception)args.ExceptionObject;

            Logger.Log("UnhandledException", ex);
        }
    }
}
