using SampleAppCore.Service.ViewModel.Blog;
using SampleAppCore.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Service.Interfaces
{
    public interface IPageService : IDisposable
    {
        void Add(PageViewModel pageVm);

        void Update(PageViewModel pageVm);

        void Delete(int id);

        List<PageViewModel> GetAll();

        PageResult<PageViewModel> GetAllPaging(string keyword, int page, int pageSize);

        PageViewModel GetByAlias(string alias);

        PageViewModel GetById(int id);

        void SaveChanges();

    }
}
