using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NumberPuzzleWeb.Core.ApplicationServices;
using NumberPuzzleWeb.Core.DomainModel;
using NumberPuzzleWeb.Core.DomainServices;
using NUnit.Framework;

namespace NumberPuzzleWeb.UnitTest
{
    class GameServiceTest
    {
        [Test]
        public async Task TestStartGame()
        {
            var mock = new Mock<IGameModelRepo>();
            mock.Setup(repo => repo.Create(It.IsAny<GameModel>())).ReturnsAsync(true);
            var gameService = new GameService();
        }
    }
}
