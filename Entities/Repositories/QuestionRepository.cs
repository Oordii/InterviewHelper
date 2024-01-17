using Entities.Models;
using Entities.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    internal sealed class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(InterviewDbContext context)
            :base(context)
        {
        }
    }
}
