using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareManager.BusinessObject;

namespace YoutubeShareManager.Repository
{
    public interface IYoutubeShareRepository
    {
        Task<List<YoutubeVideo>> GetVideos();
        Task<bool> SaveVideo(SaveYoutubeVideoRequest youtubeVideoRequest);
    }
}
