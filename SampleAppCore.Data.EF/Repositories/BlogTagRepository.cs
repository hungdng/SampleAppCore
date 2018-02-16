using SampleAppCore.Data.Entites;
using SampleAppCore.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Data.EF.Repositories
{
    public class BlogTagRepository : EFRepository<BlogTag, int>, IBlogTagRepository
    {
        public BlogTagRepository(AppDbContext context) : base(context)
        {
        }
    }
}
