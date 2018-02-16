using SampleAppCore.Service.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Service.Interfaces
{
    public interface ICommonService
    {
        FooterViewModel GetFooter();
        List<SlideViewModel> GetSlides(string groupAlias);
        SystemConfigViewModel GetSystemConfig(string code);
    }
}
