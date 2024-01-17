using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Question : EntityBase
    {
        public string Name { get; set; }

        public string Answer { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }
    }
}