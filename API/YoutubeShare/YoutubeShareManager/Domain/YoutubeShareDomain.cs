using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareManager.BusinessObject;
using YoutubeShareManager.Repository;

namespace YoutubeShareManager.Domain
{
    public class YoutubeShareDomain: IYoutubeShareDomain
    {
        private YoutubeShareRepository youtubeShareRepository;
        public YoutubeShareDomain(YoutubeShareRepository youtubeShareRepository)
        {
            this.youtubeShareRepository = youtubeShareRepository;
        }

        public async Task<List<YoutubeVideo>> GetYoutubeVideos()
        {
            return await youtubeShareRepository.GetVideos();
        }

        public async Task<bool> SaveVideo(SaveYoutubeVideoRequest youtubeVideoRequest)
        {
            return await youtubeShareRepository.SaveVideo(youtubeVideoRequest);
        }
    }
}
