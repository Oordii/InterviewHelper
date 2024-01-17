using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Topic : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
