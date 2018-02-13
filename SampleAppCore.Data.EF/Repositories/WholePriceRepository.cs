using SampleAppCore.Data.Entites;
using SampleAppCore.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.EF.Repositories
{
    public class WholePriceRepository : EFRepository<WholePrice, int>, IWholePriceRepository
    {
        public WholePriceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
