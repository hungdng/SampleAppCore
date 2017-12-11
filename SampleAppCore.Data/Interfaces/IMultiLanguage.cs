using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.Interfaces
{
    public interface IMultiLanguage<T>
    {
        T LanguageId { set; get; }
    }
}
