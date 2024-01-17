using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Abstraction
{
    public interface IRepositoryWrapper
    {
        public ITopicRepository TopicRepository { get; }

        public IQuestionRepository QuestionRepository { get; }

        void SaveChanges();
    }
}
