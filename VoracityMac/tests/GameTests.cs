using Xunit;

namespace VoracityMac.Tests
{
    public class GameTests
    {
        private Game _game;
        private int _width = 10;
        
        public GameTests()
        {
            _game = new Game(new Board(_width, new PositionFinder(_width), new SurroundingTileFinder(_width, new PositionFinder(_width))));            
        }
        
        [Fact]
        public void NewGame_TimesRemainingShouldBeOneLessThanBoardSize()
        {
            _game.NewGame();
            Assert.Equal(_width * _width - 1, _game.TilesRemaining());
        }
    }
}