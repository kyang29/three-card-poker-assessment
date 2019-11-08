using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Data
{
    public class Player
    {
        public Hand Hand { get; set; }
        public string Id { get; set; }

        public Player(string id, Hand hand)
        {
            Id = id;
            Hand = hand;
        }
    }
}
