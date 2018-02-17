using SampleAppCore.Service.ViewModel.Common;
using SampleAppCore.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Service.Interfaces
{
    public interface IFeedbackService
    {
        void Add(FeedbackViewModel feedbackVm);

        void Update(FeedbackViewModel feedbackVm);

        void Delete(int id);

        List<FeedbackViewModel> GetAll();

        PageResult<FeedbackViewModel> GetAllPaging(string keyword, int page, int pageSize);

        FeedbackViewModel GetById(int id);

        void SaveChanges();
    }
}
