using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareManager.Domain;

namespace YoutubeShareManager.Factory
{
    public interface IUserFactory
    {
        IUserDomain Create();
    }
}
