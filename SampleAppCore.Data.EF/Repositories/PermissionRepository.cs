using SampleAppCore.Data.Entites;
using SampleAppCore.Data.IRepositories;
using SampleAppCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.EF.Repositories
{
    public class PermissionRepository : EFRepository<Permission, int>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
