using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Utilities.Dtos
{
    public class PageResult<T>: PageResultBase where T:class
    {
        public PageResult()
        {
            Results = new List<T>();
        }

        public IList<T> Results { get; set; }
    }
}
