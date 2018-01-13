using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.IRepositories
{
    public interface IMultiLanguage<T>
    {
        T LanguageId { set; get; }
    }
}
