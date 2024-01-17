using Entities.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly InterviewDbContext _context;

        private ITopicRepository _topicRepository;

        private IQuestionRepository _questionRepository;

        public ITopicRepository TopicRepository
        {
            get
            {
                _topicRepository ??= new TopicRepository(_context);

                return _topicRepository;
            }
        }

        public IQuestionRepository QuestionRepository
        { 
            get
            {
                _questionRepository ??= new QuestionRepository(_context);

                return _questionRepository;
            }
        }

        public RepositoryWrapper(InterviewDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
