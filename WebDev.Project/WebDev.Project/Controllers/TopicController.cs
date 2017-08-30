using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebDev.Services.Contracts;

namespace WebDev.Project.Controllers
{
    public class TopicController : ApiController
    {
        private readonly ITopicService topicsService;
        
        public TopicController(ITopicService topicsService)
        {
            if(topicsService == null)
            {
                throw new ArgumentNullException("userService");
            }

            this.topicsService = topicsService;
        }

        [HttpGet]
        public Task<HttpResponseMessage> Index(int page, int size, string sortBy, string orderBy)
        {
            var topics = this.topicsService
                .Get(page, size, sortBy, orderBy)
                .ToList();

            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, topics));
        }

        //[HttpGet]
        //public Task<HttpResponseMessage> Words(int id, int page, int size)
        //{
        //    var topics = this.topicsService
        //        .GetTopicById(id, page, size)
        //        .ToList();

        //    return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, topics));
        //}
    }
}