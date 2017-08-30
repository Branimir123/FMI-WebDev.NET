using System.Collections.Generic;
using WebDev.Models;

namespace WebDev.Services.Contracts
{
    public interface ITopicService
    {
        void Create(Topic topic);

        IEnumerable<Topic> GetTopics();

        IEnumerable<Topic> Get(int page, int size, string sortBy = "", string orderBy = "");

        Topic GetTopicById(int id);
    }
}
