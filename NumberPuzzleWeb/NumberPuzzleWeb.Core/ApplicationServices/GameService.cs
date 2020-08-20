using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NumberPuzzleWeb.Core.DomainModel;
using NumberPuzzleWeb.Core.DomainServices;

namespace NumberPuzzleWeb.Core.ApplicationServices
{
    public class GameService
    {
        private readonly IGameModelRepo _gameModelRepo;

        public GameService(IGameModelRepo gameModelRepo)
        {
            _gameModelRepo = gameModelRepo;
        }

        public async Task<GameModel> StartGame()
        {
            var gameModel = new GameModel();
            await _gameModelRepo.Create(gameModel);
            return gameModel;
        }
    }
}
