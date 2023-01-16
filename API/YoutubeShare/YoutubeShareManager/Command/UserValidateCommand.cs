using MediatR;
using YoutubeShareManager.Envelope;

namespace YoutubeShareManager.Command
{
    public class UserValidateCommand : IRequest<UserValidateEnvelop>
    {
        public UserValidateCommand(string username,string password) 
        {
            this.UserName = username;
            this.Password = password;
        }

        public string UserName { get; set;}
        public string Password { get; set; }
    }
}
