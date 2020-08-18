using System;
using System.Threading.Tasks;
using NumberPuzzleWeb.Core.DomainModel;

namespace NumberPuzzleWeb.Core.DomainServices
{
    public interface IGameModelRepository
    {
        Task<bool> Create(GameModel gameModel);
        Task<GameModel> Read(Guid id);
        Task<bool> Update(GameModel gameModel);
    }
}
