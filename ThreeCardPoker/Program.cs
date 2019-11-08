using Poker;
using Poker.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ThreeCardPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new List<Player>();
            var stdin = Console.In;

            using (var sr = new StreamReader(Console.OpenStandardInput()))
            {
                var lines = sr.ReadToEnd().Split(new char[] { '\u001a' ,'\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                players = lines.Select(l => PokerHelper.BuildPlayerFromInputString(l)).ToList();
            }
            var winnerIds = Evaluator.GetWinners(players).Select(p => p.Id);

            Console.WriteLine("{0}",string.Join(" " ,winnerIds));
        }
    }
}