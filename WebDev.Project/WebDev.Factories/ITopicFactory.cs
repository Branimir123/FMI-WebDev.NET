using WebDev.Models;

namespace WebDev.Factories
{
    public interface ITopicFactory
    {
        Topic CreateTopic(string name, string word, User author);
    }
}
