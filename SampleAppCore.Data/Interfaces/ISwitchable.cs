using SampleAppCore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
