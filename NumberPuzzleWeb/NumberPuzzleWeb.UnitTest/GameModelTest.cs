using System;
using NumberPuzzleWeb.Core.DomainModel;
using NUnit.Framework;

namespace NumberPuzzleWeb.Core
{
    public class GameModelTest
    {
        [Test]
        public void TestIsNotSolved()
        {
            var gameModel = new GameModel(new[] {1,2,3,4,5,6,7,0,8,9});
            Assert.AreEqual(false, gameModel.IsSolved);
        }

        [Test]
        public void TestIsSolved()
        {
            var gameModel = new GameModel(new []{1,2,3,4,5,6,7,8,0});
            Assert.AreEqual(true, gameModel.IsSolved);
        }
    }
}
