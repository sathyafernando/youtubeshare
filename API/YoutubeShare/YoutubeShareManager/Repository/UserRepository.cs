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
    public class UserRepository : IUserRepository
    {
        private YoutubeShareContext youtubeShareContext;
        public UserRepository(YoutubeShareContext youtubeShareContext) {
            this.youtubeShareContext = youtubeShareContext;
        }

        public async Task<User?> GetUserByUsernameAndPassword(UserValidateRequest userRequest)
        {
            var user= await youtubeShareContext.YsUser.FirstOrDefaultAsync(i=>i.Username==userRequest.Username && i.Password==userRequest.Password);

            if (user != null)
            {
                return new User
                {
                    Id = user.Id,
                    Username = user.Username
                };
            }

            return null;
        }

        public async Task<User> SaveUser(UserValidateRequest userRequest)
        {
            YsUser ysUser =new YsUser();
            ysUser.Username= userRequest.Username;
            ysUser.Password= userRequest.Password;

            youtubeShareContext.YsUser.Add(ysUser);
            await youtubeShareContext.SaveChangesAsync();
            return new User
            {
                Id =ysUser.Id,
                Username =ysUser.Username,
            };
        }
    }
}
