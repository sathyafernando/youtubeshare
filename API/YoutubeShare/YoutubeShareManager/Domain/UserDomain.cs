using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareManager.BusinessObject;
using YoutubeShareManager.Repository;

namespace YoutubeShareManager.Domain
{
    public class UserDomain : IUserDomain
    {
        private UserRepository userRepository;
        public UserDomain(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> ValidateUser(UserValidateRequest userRequest)
        {
            var user = await userRepository.GetUserByUsernameAndPassword(userRequest);

            if (user != null)
            {
                return user;
            }

            return await userRepository.SaveUser(userRequest);
        }
    }
}
