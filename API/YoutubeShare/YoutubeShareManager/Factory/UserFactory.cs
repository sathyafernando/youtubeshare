using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareData.Models;
using YoutubeShareManager.Domain;

namespace YoutubeShareManager.Factory
{
    public class UserFactory : IUserFactory
    {
        private YoutubeShareContext youtubeShareContext;
        public UserFactory(YoutubeShareContext youtubeShareContext)
        {
            this.youtubeShareContext = youtubeShareContext;
        }

        IUserDomain IUserFactory.Create()
        {
            return new UserDomain(new Repository.UserRepository(youtubeShareContext));
        }
    }
}
