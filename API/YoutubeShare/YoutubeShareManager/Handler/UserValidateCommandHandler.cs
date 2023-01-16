using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YoutubeShareData.Models;
using YoutubeShareManager.BusinessObject;
using YoutubeShareManager.Command;
using YoutubeShareManager.Common;
using YoutubeShareManager.Envelope;
using YoutubeShareManager.Factory;

namespace YoutubeShareManager.Handler
{
    public class UserValidateCommandHandler : IRequestHandler<UserValidateCommand, UserValidateEnvelop>
    {
        private readonly IUserFactory userFactory;

        public UserValidateCommandHandler(YoutubeShareContext youtubeShareContext)
        {
            this.userFactory = new UserFactory(youtubeShareContext);
        }

        public async Task<UserValidateEnvelop> Handle(UserValidateCommand userValidateCommand,CancellationToken cancellationToken)
        {
            var userDomain = this.userFactory.Create();
            try
            {
                var userRequest = new UserValidateRequest
                {
                    Username = userValidateCommand.UserName,
                    Password = userValidateCommand.Password
                };

                var user = await userDomain.ValidateUser(userRequest);
                
                if (user==null)
                {
                    var errorMessage = "Request fail due to invalid user";
                    Error error = new Error(ErrorType.UNAUTHORIZED, errorMessage);
                    return new UserValidateEnvelop(false, string.Empty, error);
                }

                return new UserValidateEnvelop(true, "Request process successfully",user.Id, user.Username);

            }
            catch (Exception e)
            {
                var errorMessage = e.Message;
                Error error = new Error(ErrorType.BAD_REQUEST, errorMessage);
                return new UserValidateEnvelop(false, string.Empty, error);
            }
        }
    }
}
