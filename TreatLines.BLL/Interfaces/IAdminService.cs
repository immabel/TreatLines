using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.BLL.DTOs.Admin;

namespace TreatLines.BLL.Interfaces
{
    public interface IAdminService
    {
        Task<AdminProfileInfoDTO> GetAdminProfileInfoAsync(string email);
        Task UpdateUserInfoAsync(AdminProfileInfoDTO adminDTO);
        public void CreateDbBackup();
    }
}
