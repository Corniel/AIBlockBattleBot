
using System;
using System.Collections.Generic;
using System.IO;

namespace AIBlockBattleBot
{
    class Bot : IDisposable, IEngineCommandReceiver
    {
        public MatchSettings MatchSettings { get; private set; }
        public GameState GameState { get; private set; }
        public Dictionary<string, PlayerState> Players { get; private set; }

        public Bot()
        {
            MatchSettings = new MatchSettings();
            GameState = new GameState();
            Players = new Dictionary<string, PlayerState>();
        }

        public void Run()
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            using (var parser = new Parser())
            {
                EngineCommand command;
                while ((command = parser.PollCommand(this)) != null)
                {
                    if (command.Receiver != null)
                        command.Execute();
                }
            }
        }

        public void ReceiveCommand(EngineCommand command)
        {
            var parameters = command.Parameters;

            switch ((string)parameters[0])
            {
                case "moves":
                    var moves = MovesForRound(int.Parse((string)parameters[1]));
                    if (moves.Length == 0)
                    {
                        Console.WriteLine("no_moves");
                    }
                    else
                    {
                        Console.WriteLine("{0},drop", string.Join(",", moves).ToLower());
                    }
                    break;

                default:
                    Console.WriteLine("Invalid bot action: {0}", (string)parameters[0]);
                    break;
            }
        }

        private MoveType[] MovesForRound(int milliseconds)
        {
            var random = new Random();
            var moveValues = Enum.GetValues(typeof (MoveType));
            var moves = new List<MoveType>();

            for (var i = 0; i < moveValues.Length; i++)
            {
                moves.Add((MoveType)Enum.ToObject(typeof(MoveType), random.Next(0, moveValues.Length - 1)));
            }

            return moves.ToArray();
        }

        public void Dispose()
        {
        }

    }
}
