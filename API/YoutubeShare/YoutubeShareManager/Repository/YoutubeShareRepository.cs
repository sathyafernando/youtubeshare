using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareData.Models;
using YoutubeShareManager.BusinessObject;

namespace YoutubeShareManager.Repository
{
    public class YoutubeShareRepository:IYoutubeShareRepository
    {
        private YoutubeShareContext youtubeShareContext;
        public YoutubeShareRepository(YoutubeShareContext youtubeShareContext) {
            this.youtubeShareContext = youtubeShareContext;
        }

        public async Task<List<YoutubeVideo>> GetVideos()
        {
            List<YoutubeVideo> youtubeVideos= new List<YoutubeVideo>();
            var videos= await youtubeShareContext.YsVideo.ToListAsync();

            videos.ForEach(video =>
            {
                youtubeVideos.Add(new YoutubeVideo
                {
                    Id= video.Id,
                    VideoLink= video.VideoLink,
                });
            });

            return youtubeVideos;
        }

        public async Task<bool> SaveVideo(SaveYoutubeVideoRequest youtubeVideoRequest)
        {
            YsVideo ysVideo =new YsVideo();
            ysVideo.VideoLink= youtubeVideoRequest.VideoLink;

            youtubeShareContext.YsVideo.Add(ysVideo);
            await youtubeShareContext.SaveChangesAsync();
            return true;
        }
    }
}
