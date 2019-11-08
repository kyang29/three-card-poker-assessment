using Poker;
using Poker.Data;
using Poker.Enums;
using Poker.Extensions;

namespace ThreeCardPoker
{
    public static class PokerHelper
    {
        public static Player BuildPlayerFromInputString(string inputLine){
            string[] inputs = inputLine.Split();

            var hand = new Hand();

            for (int k = 1; k < inputs.Length; k++){
                hand.Cards.Add(BuildCardFromInput(inputs[k]));
            }
            return new Player(inputs[0], hand);
        }

        public static PlayingCard BuildCardFromInput(string input)
        {
            return new PlayingCard()
            {
                Rank = (Rank) EnumHelper<Rank>.GetValueFromDisplayName(input[0].ToString()),
                Suit = (Suit) EnumHelper<Suit>.GetValueFromDisplayName(input[1].ToString())
            };
        }
    }
}
