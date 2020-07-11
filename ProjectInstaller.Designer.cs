namespace SimpleService
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
            this.simpleServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.simpleServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // simpleServiceProcessInstaller
            // 
            this.simpleServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.simpleServiceProcessInstaller.Password = null;
            this.simpleServiceProcessInstaller.Username = null;
            // 
            // simpleServiceInstaller
            // 
            this.simpleServiceInstaller.Description = "Simple Demo Service";
            this.simpleServiceInstaller.DisplayName = "SimpleService";
            this.simpleServiceInstaller.ServiceName = "SimpleService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.simpleServiceProcessInstaller,
            this.simpleServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller simpleServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller simpleServiceInstaller;
    }
}