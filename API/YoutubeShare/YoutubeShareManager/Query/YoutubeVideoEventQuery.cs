using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeShareManager.Envelope;

namespace YoutubeShareManager.Query
{
    public class YoutubeVideoEventQuery : IRequest<YoutubeQueryEnvelop>
    {
    }
}
