using SampleAppCore.Data.Entites;
using SampleAppCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.IRepositories
{
    public interface IPageRepository : IRepository<Page, int>
    {
    }
}
