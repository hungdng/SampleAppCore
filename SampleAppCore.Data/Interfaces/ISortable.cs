using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.Interfaces
{
    public interface ISortable
    {
        int SortOrder { set; get; }
    }
}
