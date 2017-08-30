using System;
using System.Collections.Generic;
using System.Linq;
using WebDev.Data.Contracts;
using WebDev.Models;
using WebDev.Services.Contracts;

namespace WebDev.Services
{
    public class TopicService : ITopicService
    {
        private readonly IRepository<Topic> topicRepository;
        private readonly IUnitOfWork unitOfWork;

        public TopicService(IRepository<Topic> topicRepository, IUnitOfWork unitOfWork)
        {
            if(topicRepository == null)
            {
                throw new ArgumentNullException("Topic Repository");
            }

            if(unitOfWork == null)
            {
                throw new ArgumentNullException("Unit Of Work");
            }

            this.topicRepository = topicRepository;
            this.unitOfWork = unitOfWork;
        }
        public void Create(Topic topic)
        {
            this.topicRepository.Add(topic);
        }

        public Topic GetTopicById(int id)
        {
            return this.topicRepository.GetById(id);
        }

        public IEnumerable<Topic> GetTopics()
        {
            return this.topicRepository.GetAll.ToList();
        }
    }
}
