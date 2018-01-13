using SampleAppCore.Service.ViewModel.System;
using SampleAppCore.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppCore.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(AppUserViewModel userVm);
        Task DeleteAsync(string id);

        Task<List<AppUserViewModel>> GetAllAsync();

        PageResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppUserViewModel> GetByIdAsync(string id);

        Task UpdateAsync(AppUserViewModel userVm);
    }
}
