using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeShareAPI.Request;
using YoutubeShareManager.Command;
using YoutubeShareManager.Envelope;
using YoutubeShareManager.Query;

namespace YoutubeShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeVideoController : ControllerBase
    {
        private readonly IMediator mediator;
        public YoutubeVideoController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        [Route("GetVideos")]
        public async Task<JsonResult> GetVideos()
        {
            var youtubeVideos = await mediator.Send(new YoutubeVideoEventQuery());
            return new JsonResult(youtubeVideos);
        }

        [HttpPost]
        [Route("ShareVideo")]
        public async Task<JsonResult> ShareVideo(YoutubeVideoRequest youtubeVideoRequest)
        {
            var result = await mediator.Send(new YoutubeVideoSaveCommand(youtubeVideoRequest.VideoLink));

            return new JsonResult(result);
        }
    }
}
