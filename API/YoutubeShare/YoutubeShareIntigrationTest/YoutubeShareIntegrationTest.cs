using MediatR;
using YoutubeShareManager.Command;

namespace YoutubeShareIntegrationTest
{
    public class YoutubeShareIntegrationTest
    {
        private IMediator mediator;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Test1()
        {
            var r1 = await mediator.Send(new YoutubeVideoSaveCommand("http://www.youtube.com/watch?v=tw8FI-833yI"));

            Assert.IsTrue(r1.Created);

            var r2 = await mediator.Send(new YoutubeVideoSaveCommand("https://www.youtube.com/watch?v=tw8FI-833yI"));

            Assert.IsTrue(r2.Created);

            var r3 = await mediator.Send(new YoutubeVideoSaveCommand("http://youtu.be/tw8FI-833yI"));

            Assert.IsTrue(r3.Created);

            var r4 = await mediator.Send(new YoutubeVideoSaveCommand("www.youtube.com/watch?v=tw8FI-833yI"));

            Assert.IsTrue(r4.Created);

            var r5 = await mediator.Send(new YoutubeVideoSaveCommand("youtu.be/tw8FI-833yI "));

            Assert.IsTrue(r5.Created);

            var r6 = await mediator.Send(new YoutubeVideoSaveCommand("http://www.youtube.com/watch?feature=player_embedded&v=tw8FI-833yI "));

            Assert.IsTrue(r6.Created);

            var r7 = await mediator.Send(new YoutubeVideoSaveCommand("www.youtube.com/watch?feature=player_embedded&v=tw8FI-833yI "));

            Assert.IsTrue(r7.Created);

            var r8 = await mediator.Send(new YoutubeVideoSaveCommand("http://www.youtube.com/watch?v=_-QpUDvTdNY"));

            Assert.IsTrue(r8.Created);
        }
    }
}