using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareManager.BusinessObject;

namespace YoutubeShareManager.Envelope
{
    public class YoutubeQueryEnvelop
    {
        public YoutubeQueryEnvelop(List<YoutubeVideo> youtubeVideos)
        {
            this.YoutubeVideos= youtubeVideos;
        }

        public List<YoutubeVideo> YoutubeVideos { get; set; }
    }
}
