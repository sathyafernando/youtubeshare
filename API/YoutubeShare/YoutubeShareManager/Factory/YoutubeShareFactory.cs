using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareData.Models;
using YoutubeShareManager.Domain;

namespace YoutubeShareManager.Factory
{
    public class YoutubeShareFactory : IYoutubeShareFactory
    {
        private YoutubeShareContext youtubeShareContext;
        public YoutubeShareFactory(YoutubeShareContext youtubeShareContext)
        {
            this.youtubeShareContext = youtubeShareContext;
        }

        IYoutubeShareDomain IYoutubeShareFactory.Create()
        {
            return new YoutubeShareDomain(new Repository.YoutubeShareRepository(youtubeShareContext));
        }
    }
}
