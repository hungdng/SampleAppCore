using SampleAppCore.Service.ViewModel.Common;
using SampleAppCore.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Service.Interfaces
{
    public interface IContactService
    {
        void Add(ContactViewModel contactVm);

        void Update(ContactViewModel contactVm);

        void Delete(string id);

        List<ContactViewModel> GetAll();

        PageResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize);

        ContactViewModel GetById(string id);

        void SaveChanges();
    }
}
