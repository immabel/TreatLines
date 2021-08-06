using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Admin;
using TreatLines.BLL.Interfaces;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Repositories;

namespace TreatLines.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserRepository userRepository;

        public AdminService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<AdminProfileInfoDTO> GetAdminProfileInfoAsync(string id)
        {
            TreatLines.DAL.Entities.User user = await userRepository.FindByIdAsync(id);

            var result = new AdminProfileInfoDTO
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return result;
        }

        public void CreateDbBackup()
        {
            object locker = new object();
            lock (locker)
            {
                Backup backup = new Backup
                {
                    Action = BackupActionType.Database,
                    Database = "TrLinesDB"
                };

                Server server = new Server("NATALI\\SQLEXPRESS");
                backup.Devices.AddDevice(@"C:\Users\Natali\Desktop\Marina\StudyingNIX\MainProject\backup\TrLinesDB.bak", DeviceType.File);
                backup.BackupSetName = "trLinesDbBackup";
                backup.BackupSetDescription = "trLinesDbBackup";
                backup.ExpirationDate = DateTime.Today.AddDays(10);
                backup.Initialize = false;
                backup.SqlBackup(server);
            }
        }

        public async Task UpdateUserInfoAsync(AdminProfileInfoDTO adminDTO)
        {
            TreatLines.DAL.Entities.User user = await userRepository.FindByEmailAsync(adminDTO.Email);
            user.FirstName = adminDTO.FirstName;
            user.LastName = adminDTO.LastName;
            user.PhoneNumber = adminDTO.PhoneNumber;
            await userRepository.UpdateAsync(user);
        }
    }
}
