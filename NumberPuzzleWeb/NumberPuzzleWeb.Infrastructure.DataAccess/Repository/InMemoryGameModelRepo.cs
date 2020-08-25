﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NumberPuzzleWeb.Core.DomainModel;
using NumberPuzzleWeb.Core.DomainServices;

namespace NumberPuzzleWeb.Infrastructure.DataAccess.Repository
{
    public class InMemoryGameModelRepo : IGameModelRepo
    {
        private readonly Dictionary<Guid, GameModel> _gameModels;

        public InMemoryGameModelRepo()
        {
            _gameModels = new Dictionary<Guid, GameModel>();
        }
        public Task<bool> Create(GameModel gameModel)
        {
            _gameModels.Add(gameModel.Id, gameModel);
            return Task.FromResult(true);
        }

        public Task<GameModel> Read(Guid id)
        {
            return Task.FromResult(_gameModels[id]);
        }

        public Task<bool> Update(GameModel gameModel)
        {
            _gameModels[gameModel.Id] = gameModel;
            return Task.FromResult(true);
        }
    }
}
