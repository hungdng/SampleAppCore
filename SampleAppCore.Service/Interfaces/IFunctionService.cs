﻿using SampleAppCore.Service.ViewModel.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppCore.Service.Interfaces
{
    public interface IFunctionService: IDisposable
    {
        Task<List<FunctionViewModel>> GetAll();

        List<FunctionViewModel> GetAllByPermission(Guid userId);
    }
}
