using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.IRepositories
{
    public interface ISortable
    {
        int SortOrder { set; get; }
    }
}
