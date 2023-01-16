using MediatR;
using YoutubeShareManager.Envelope;

namespace YoutubeShareManager.Command
{
    public class YoutubeVideoSaveCommand:IRequest<RequestSaveEnvelop>
    {
        public YoutubeVideoSaveCommand(string youtubeVideoLink) 
        {
            this.YoutubeVideoLink = youtubeVideoLink;
        }

        public string YoutubeVideoLink { get; set;}
    }
}
