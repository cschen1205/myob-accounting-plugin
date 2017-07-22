using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Accounting.Service.DbBackup
{
    public partial class DbBackupService : ServiceBase
    {
        public DbBackupService()
        {
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("AccDbBackupSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "AccDbBackupSource", "AccBackBackupLog");
            }
            eventLogDbBackup.Source = "AccDbBackupSource";
            eventLogDbBackup.Log = "AccBackBackupLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLogDbBackup.WriteEntry("In AccDbBackupService.OnStart");
        }

        protected override void OnStop()
        {
            eventLogDbBackup.WriteEntry("In AccDbBackupService.OnStop.");
        }

        protected override void OnContinue()
        {
            eventLogDbBackup.WriteEntry("In AccDbBackupService.OnContinue.");
        }  

    }
}
