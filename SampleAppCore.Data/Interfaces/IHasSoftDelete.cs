using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.IRepositories
{
    public interface IHasSoftDelete
    {
        bool IDeleted { set; get; }
    }
}
