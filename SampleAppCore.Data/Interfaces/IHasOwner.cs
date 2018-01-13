using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.IRepositories
{
    public interface IHasOwner<T>
    {
        T OwnerId { set; get; }
    }
}
