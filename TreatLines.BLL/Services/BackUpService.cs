using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.BLL.Interfaces;

namespace TreatLines.BLL.Services
{
    public class BackUpService : IBackUpService
    {
        public BackUpService() { }

        public void CreateDbBackup()
        {
            object locker = new object();
            lock (locker)
            {
                Backup backup = new Backup
                {
                    Action = BackupActionType.Database,
                    Database = "TreatLinesDB"
                };

                Server server = new Server("NATALI\\SQLEXPRESS");
                backup.Devices.AddDevice(@"C:\Users\Natali\Desktop\Marina\StudyingNIX\MainProject\backup\TrLinesDB.bak", DeviceType.File);
                backup.BackupSetName = "treatLinesDbBackup";
                backup.BackupSetDescription = "treatLinesDbBackup";
                backup.ExpirationDate = DateTime.Today.AddDays(10);
                backup.Initialize = false;
                backup.SqlBackup(server);
            }
        }
    }
}
