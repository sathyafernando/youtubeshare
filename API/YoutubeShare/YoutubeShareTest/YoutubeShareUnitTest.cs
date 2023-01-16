using Moq;
using YoutubeShareData.Models;
using YoutubeShareManager.Factory;
using YoutubeShareManager.Handler;

namespace YoutubeShareTest
{
    public class YoutubeShareUnitTest
    {
        private YoutubeVideoSaveCommandHandler _handler;
        private Mock<IYoutubeShareFactory> _factory;
        private Mock<YoutubeShareContext> _context;

        string _url;

        [SetUp]
        public void Setup()
        {
            _context=new Mock<YoutubeShareContext>();
            _factory=new Mock<IYoutubeShareFactory>();
            _handler=new YoutubeVideoSaveCommandHandler(_context.Object);

            _url = $"https://www.youtube.com/embed/hZbQTYybmZE";
        }

        [Test]
        public void ValidateYoutubeUrl()
        {
            var youtubeLink = _handler.ConvertYoutubeLink("https://www.youtube.com/watch?v=hZbQTYybmZE");
            Assert.AreEqual(_url, youtubeLink);
        }
    }
}