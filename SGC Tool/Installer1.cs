using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Runtime.InteropServices;


namespace SGC_Tool
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            RegistrationServices regSrv = new RegistrationServices();
            regSrv.RegisterAssembly(base.GetType().Assembly,
              AssemblyRegistrationFlags.SetCodeBase);
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
            RegistrationServices regSrv = new RegistrationServices();
            regSrv.UnregisterAssembly(base.GetType().Assembly);
        }
        public override void Commit(System.Collections.IDictionary stateSaver)
        {
            base.Commit(stateSaver);
            RegistrationServices regSrv = new RegistrationServices();
            regSrv.RegisterAssembly(base.GetType().Assembly,
              AssemblyRegistrationFlags.SetCodeBase);
            DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\FrontEndTool");
            foreach (FileInfo fileInfo in directoryInfo.GetFiles("setup.*"))
            {
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }
        }
    }
}
