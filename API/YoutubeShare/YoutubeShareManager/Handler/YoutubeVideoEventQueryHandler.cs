using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareData.Models;
using YoutubeShareManager.Envelope;
using YoutubeShareManager.Factory;
using YoutubeShareManager.Query;

namespace YoutubeShareManager.Handler
{
    public class YoutubeVideoEventQueryHandler:IRequestHandler<YoutubeVideoEventQuery,YoutubeQueryEnvelop>
    {
        private readonly IYoutubeShareFactory youtubeShareFactory;

        public YoutubeVideoEventQueryHandler(YoutubeShareContext youtubeShareContext)
        {
            this.youtubeShareFactory=new YoutubeShareFactory(youtubeShareContext);
        }

        public async Task<YoutubeQueryEnvelop> Handle(YoutubeVideoEventQuery youtubeVideoEventQuery, CancellationToken cancellationToken)
        {
            var youtubeDomain = this.youtubeShareFactory.Create();
            var youtubeVideos = await youtubeDomain.GetYoutubeVideos();

            return new YoutubeQueryEnvelop(youtubeVideos);
        }
    }
}
