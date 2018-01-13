using SampleAppCore.Service.ViewModel.System;
using SampleAppCore.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppCore.Service.Interfaces
{
    public interface IRoleService
    {
        Task<bool> AddAsync(AppRoleViewModel roleVm);

        Task DeleteAsync(Guid id);

        Task<List<AppRoleViewModel>> GetAllAsync();

        PageResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppRoleViewModel> GetByIdAsync(Guid Id);

        Task UpdateAsync(AppRoleViewModel roleVm);

        List<PermissionViewModel> GetListFunctionWithRole(Guid roleId);

        void SavePermission(List<PermissionViewModel> permissionVms, Guid roleId);

        Task<bool> CheckPermission(string functionId, string action, string[] roles);
    }
}
