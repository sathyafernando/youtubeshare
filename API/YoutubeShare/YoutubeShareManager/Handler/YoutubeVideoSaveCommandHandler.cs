using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YoutubeShareData.Models;
using YoutubeShareManager.BusinessObject;
using YoutubeShareManager.Command;
using YoutubeShareManager.Common;
using YoutubeShareManager.Envelope;
using YoutubeShareManager.Factory;

namespace YoutubeShareManager.Handler
{
    public class YoutubeVideoSaveCommandHandler:IRequestHandler<YoutubeVideoSaveCommand, RequestSaveEnvelop>
    {
        private readonly IYoutubeShareFactory youtubeShareFactory;

        public YoutubeVideoSaveCommandHandler(YoutubeShareContext youtubeShareContext)
        {
            this.youtubeShareFactory=new YoutubeShareFactory(youtubeShareContext);
        }

        public async Task<RequestSaveEnvelop> Handle(YoutubeVideoSaveCommand youtubeVideoSaveCommand,CancellationToken cancellationToken)
        {
            var youtubeDomain = this.youtubeShareFactory.Create();
            try
            {
                var youtubeLink = ConvertYoutubeLink(youtubeVideoSaveCommand.YoutubeVideoLink);
                
                var youtubeRequest = new SaveYoutubeVideoRequest { VideoLink = youtubeLink };
                var response = await youtubeDomain.SaveVideo(youtubeRequest);

                if (!response)
                {
                    var errorMessage = "Request fail due to invalid user";
                    Error error = new Error(ErrorType.UNAUTHORIZED, errorMessage);
                    return new RequestSaveEnvelop(false, string.Empty, error);
                }

                return new RequestSaveEnvelop(response, "Request process successfully", null);

            }
            catch (Exception e)
            {
                var errorMessage = e.Message;
                Error error = new Error(ErrorType.BAD_REQUEST, errorMessage);
                return new RequestSaveEnvelop(false, string.Empty, error);
            }
        }

        public string ConvertYoutubeLink(string videoLink)
        {
            const string pattern = @"(?:https?:\/\/)?(?:www\.)?(?:(?:(?:youtube.com\/watch\?[^?]*v=|youtu.be\/)([\w\-]+))(?:[^\s?]+)?)";
            const string replacement = "https://www.youtube.com/embed/$1";

            var rgx = new Regex(pattern);
            return rgx.Replace(videoLink, replacement);
        } 
    }
}
