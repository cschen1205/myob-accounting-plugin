namespace Accounting.Service.DbBackup
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstallerDbBackup = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerDbBackup = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerDbBackup
            // 
            this.serviceProcessInstallerDbBackup.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.serviceProcessInstallerDbBackup.Password = null;
            this.serviceProcessInstallerDbBackup.Username = null;
            // 
            // serviceInstallerDbBackup
            // 
            this.serviceInstallerDbBackup.ServiceName = "AccDbBackupService";
            this.serviceInstallerDbBackup.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerDbBackup,
            this.serviceInstallerDbBackup});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerDbBackup;
        private System.ServiceProcess.ServiceInstaller serviceInstallerDbBackup;
    }
}