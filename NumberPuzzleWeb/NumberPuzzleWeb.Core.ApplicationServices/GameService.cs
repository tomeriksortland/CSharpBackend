
using System;
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

        public async Task<GameModel> Read(Guid gameId)
        {
            return await _gameModelRepo.Read(gameId);
        }

        public async Task<GameModel> Play(int index, Guid gameId)
        {
            var gameModel = await _gameModelRepo.Read(gameId);
            var hasPlayed = gameModel.Play(index);
            await _gameModelRepo.Update(gameModel);
            return gameModel;
        }
    }
}
