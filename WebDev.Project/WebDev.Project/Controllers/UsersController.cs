using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebDev.Models;
using WebDev.Services.Contracts;

namespace WebDev.Project.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException("User Service");
            }

            this.userService = userService;
        }

        [HttpPost]
        public Task<HttpResponseMessage> Index([FromBody] User user)
        {
            this.userService.Create(user);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.Created));
        }

        // GET Users/Get/{id}
        [HttpGet]
        public Task<HttpResponseMessage> Get(string id)
        {
            var user = userService.GetUserById(id);
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, user));
        }
    }
}