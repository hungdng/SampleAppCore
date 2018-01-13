using SampleAppCore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.IRepositories
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
