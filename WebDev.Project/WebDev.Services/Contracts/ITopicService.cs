using System.Collections.Generic;
using WebDev.Models;

namespace WebDev.Services.Contracts
{
    public interface ITopicService
    {
        void Create(Topic topic);

        IEnumerable<Topic> GetTopics();

        Topic GetTopicById(int id);
    }
}
