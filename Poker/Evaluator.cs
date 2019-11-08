using Poker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    public static class Evaluator
    {
        public static List<Player> GetWinners(List<Player> players)
        {
            var topPlayers = new List<Player>();
            var orderedPlayers = players.OrderByDescending(p => p.Hand).ToList();
            return orderedPlayers.Where(p => p.Hand.CompareTo(orderedPlayers[0].Hand) == 0).ToList();
        }
    }
}
