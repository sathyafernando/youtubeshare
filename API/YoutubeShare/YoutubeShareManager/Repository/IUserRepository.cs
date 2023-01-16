using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareManager.BusinessObject;

namespace YoutubeShareManager.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAndPassword(UserValidateRequest userRequest);
        Task<User> SaveUser(UserValidateRequest userRequest);
    }
}
