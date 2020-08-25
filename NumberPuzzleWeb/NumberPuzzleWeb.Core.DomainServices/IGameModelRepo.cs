using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using NumberPuzzleWeb.Core.DomainModel;

namespace NumberPuzzleWeb.Core.DomainServices
{
    public interface IGameModelRepo
    {
        Task<bool> Create(GameModel gameModel);
        Task<GameModel> Read(Guid id);
        Task<bool> Update(GameModel gameModel);

    }
}
