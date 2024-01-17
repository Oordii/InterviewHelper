using Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Entities.Repositories
{
    public class InterviewDbContext : DbContext
    {
        public InterviewDbContext() : base()
        {               
        }

        public InterviewDbContext(DbContextOptions<InterviewDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Questions)
                .WithOne(e => e.Topic)
                .HasForeignKey(e => e.TopicId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Topic>().HasData( new Topic() { Id = 1, Name = "Test topic" });
            modelBuilder.Entity<Question>().HasData(new Question() { Id = 1, Name = "Test question 1", Answer = "1", TopicId = 1 });
            modelBuilder.Entity<Question>().HasData(new Question() { Id = 2, Name = "Test question 2", Answer = "2", TopicId = 1 });
            modelBuilder.Entity<Question>().HasData(new Question() { Id = 3, Name = "Test question 3", Answer = "3", TopicId = 1 });


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Topic> Topics { get; set; }

        public DbSet<Question> Questions { get; set; }
    }
}
