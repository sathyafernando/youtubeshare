using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareManager.BusinessObject;

namespace YoutubeShareManager.Domain
{
    public interface IUserDomain
    {
        Task<User> ValidateUser(UserValidateRequest userRequest);
    }
}
