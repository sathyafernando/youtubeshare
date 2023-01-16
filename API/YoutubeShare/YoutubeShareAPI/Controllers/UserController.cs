using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeShareAPI.Request;
using YoutubeShareManager.BusinessObject;
using YoutubeShareManager.Command;

namespace YoutubeShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<JsonResult> Login(UserRequest userRequest)
        {
            var result = await mediator.Send(new UserValidateCommand(userRequest.Username, userRequest.Password));

            return new JsonResult(result);
        }
    }
}
