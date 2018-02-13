using SampleAppCore.Data.Entites;
using SampleAppCore.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.EF.Repositories
{
    public class BillRepository : EFRepository<Bill, int>, IBillRepository
    {
        public BillRepository(AppDbContext context) : base(context)
        {
        }
    }
}
