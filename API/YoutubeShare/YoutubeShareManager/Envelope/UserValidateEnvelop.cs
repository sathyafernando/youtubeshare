using System;
using System.Collections.Generic;
using System.Text;
using YoutubeShareManager.Common;

namespace YoutubeShareManager.Envelope
{
    public class UserValidateEnvelop
    {
        public UserValidateEnvelop(bool validate,string successMessage, Error error)
        {
            this.Validate = validate;
            this.SuccessMessage = successMessage;
            this.Error = error;
        }

        public UserValidateEnvelop(bool validate, string successMessage,long id, string username)
        {
            this.Validate = validate;
            this.SuccessMessage = successMessage;
            this.Username = username;
            this.Id = id;
        }

        public bool Validate { get; set; }
        public long Id { get; set; }
        public string SuccessMessage { get; set; }
        public Error Error { get; set; }
        public string Username { get; set; }
    }
}
