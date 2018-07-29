using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProject.Manager
{
    public class Logger
    {

        private readonly HubConnection signalR;
        private readonly IHubProxy signalRhub;
        private readonly string loggerUrl;

        public Logger()
        {
            loggerUrl = ConfigurationManager.AppSettings["LoggerUrl"];
            signalR = new HubConnection(loggerUrl);
            signalRhub = signalR.CreateHubProxy("logger");
            signalR.Start().Wait();
        }

        public void LogMessage(DateTime logDateTime, string username, string title, string description, string severity)
        {
            signalRhub.Invoke("logMessage", logDateTime, username, title, description, severity);
        }
    }
}
