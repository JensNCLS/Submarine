﻿using Contracts;
using Entities;
using Entities.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreatePlayer(Player player)
        {
            Create(player);
        }

        public void DeletePlayer(Player player)
        {
            Update(player);
        }

        public Player GetPlayerById(Guid player_id)
        {
            return FindByCondition(player => player.UserId.Equals(player_id)).FirstOrDefault();
        }

        public void UpdatePlayer(Player player)
        {
            Update(player);
        }
    }
}
