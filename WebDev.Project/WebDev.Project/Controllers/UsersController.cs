using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebDev.Project.Models;
using WebDev.Services.Contracts;

namespace WebDev.Project.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController()
        {
            
        }

        public UsersController(IUserService userService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException("User Service");
            }

            this.userService = userService;
        }
        
        [Route("api/users/register")]
        [HttpPost]
        public Task<HttpResponseMessage> Register([FromBody] RegisterUser userInfo)
        {
            //TODO check if user exists, if it does return something else

            var user = this.userService.Register(
                userInfo.UserName,
                userInfo.Password,
                userInfo.FullName,
                userInfo.Email
                );

            if (user != null)
            {
                var registeredUser = new ReadyUser(
                    user.UserId,
                    user.UserName,
                    user.PasswordHash,
                    user.Name,
                    user.Email,
                    user.IsAdmin
                    );

                return Task.FromResult(Request.CreateResponse(HttpStatusCode.Created, registeredUser));

            }
            else
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.Conflict));
            }

        }
        
        [Route("api/users/login")]
        [HttpPost]
        public Task<HttpResponseMessage> Login([FromBody] LoginUser login)
        {
            string authKey = this.userService.Login(login.Username, login.Password);

            if (authKey != string.Empty)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.Created, authKey));
            }

            return Task.FromResult(Request.CreateResponse(HttpStatusCode.Forbidden));
        }
    }
}