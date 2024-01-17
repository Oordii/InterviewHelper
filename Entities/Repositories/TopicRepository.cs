using Entities.Models;
using Entities.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    internal sealed class TopicRepository : RepositoryBase<Topic>, ITopicRepository 
    {
        public TopicRepository(InterviewDbContext context)
            :base(context)
        {    
        }
    }
}
