﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTicTacToe.Shared
{
    public class GameRoom(string roomId, string roomName)
    {
        public string RoomId { get; set; } = roomId;
        public string RoomName { get; set; } = roomName;
        public List<Player> Players { get; set; } = new();
        public TicTacToeGame Game { get; set; } = new();

        public bool TryAddPlayer(Player newPlayer)
        {
            if (Players.Count<2 &&
                !Players.Any(p=>p.ConnectionId == newPlayer.ConnectionId))
            {
                Players.Add(newPlayer);

                if(Players.Count==1)
                {
                    Game.PlayerXId= newPlayer.ConnectionId; 
                }
                else if (Players.Count==2)
                {
                    Game.PlayerOId= newPlayer.ConnectionId;
                }
                return true;
            }
            return false;
        }
    }
}
