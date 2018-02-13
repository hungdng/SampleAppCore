using SampleAppCore.Data.Entites;
using SampleAppCore.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.EF.Repositories
{
    public class BillDetailRepository : EFRepository<BillDetail, int>, IBillDetailRepository
    {
        public BillDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}
