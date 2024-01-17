



using Entities.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Question_And_Topic_Repositories_Test_Add_And_Get()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<InterviewDbContext>()
                .UseInMemoryDatabase("test database")
                .Options;
            var context = new InterviewDbContext(options);
            IRepositoryWrapper wrapper = new RepositoryWrapper(context);
            var expectedTopic = new Topic()
            {
                Id = 1,
                Name = "test"
            };
            var expectedQuestion1 = new Question()
            {
                Id = 1,
                Name = "test 1",
                Answer = "answer 1",
                TopicId = 1,
            };
            var expectedQuestion2 = new Question()
            {
                Id = 2,
                Name = "test 2",
                Answer = "answer 2",
                TopicId = 1,
            };

            //Act
            wrapper.TopicRepository.Add(expectedTopic);
            wrapper.QuestionRepository.Add(expectedQuestion1);
            wrapper.QuestionRepository.Add(expectedQuestion2);
            wrapper.SaveChanges();
            var actualTopic = wrapper.TopicRepository.GetById(expectedTopic.Id);
            var actualQuestion1 = wrapper.QuestionRepository.GetById(expectedQuestion1.Id);
            var actualQuestion2 = wrapper.QuestionRepository.GetById(expectedQuestion2.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(actualTopic, Is.Not.Null);
                Assert.That(actualQuestion1, Is.Not.Null);
                Assert.That(actualQuestion2, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(actualTopic.Name, Is.EqualTo(expectedTopic.Name));
                Assert.That(actualQuestion1.Name, Is.EqualTo(expectedQuestion1.Name));
                Assert.That(actualQuestion2.Name, Is.EqualTo(expectedQuestion2.Name));
            });
        }

        [Test]
        public void TopicRepository_Updates_Entities()
        {
            var options = new DbContextOptionsBuilder<InterviewDbContext>()
                .UseInMemoryDatabase("test database")
                .Options;
            var context = new InterviewDbContext(options);
            IRepositoryWrapper wrapper = new RepositoryWrapper(context);
            var expectedTopic = new Topic()
            {
                Id = 1,
                Name = "test(updated)"
            };


            wrapper.TopicRepository.Add(new Topic { Id = 1, Name = "test" });
            wrapper.TopicRepository.GetById(expectedTopic.Id).Name = expectedTopic.Name;
            var actual = wrapper.TopicRepository.GetById(expectedTopic.Id);


            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Name, Is.EqualTo(expectedTopic.Name));
        }
    }
}