using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.IRepositories
{
    public interface IHasSeoMetaData
    {
        string SeoPageTitle { set; get; }

        string SeoAlias { set; get; }

        string SeoKeywords { set; get; }

        string SeoDescription { set; get; }
    }
}
