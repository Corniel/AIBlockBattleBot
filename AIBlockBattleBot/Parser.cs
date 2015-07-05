using System;
using System.Linq;

namespace AIBlockBattleBot
{
    class Parser : IDisposable
    {
        public EngineCommand PollCommand(Bot bot)
        {
            var line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
                return null;

            IEngineCommandReceiver receiver = null;
            object[] parameters = null;
            var parse = line.Split(' ');
            switch (parse[0])
            {
                case "settings":
                    receiver = bot.MatchSettings;
                    parameters = new object[] {parse[1], parse[2]};
                    break;
                case "update":
                    if (parse[1] == "game")
                    {
                        receiver = bot.GameState;
                    }
                    else
                    {
                        if (bot.MatchSettings.PlayerNames.Contains(parse[1]))
                        {
                            if (!bot.Players.ContainsKey(parse[1]))
                            {
                                bot.Players.Add(parse[1], new PlayerState(bot.MatchSettings.FieldWidth, bot.MatchSettings.FieldHeight));
                            }
                            receiver = bot.Players[parse[1]];
                        }
                        else
                        {
                            Console.WriteLine("Invalid player: '{0}'", parse[1]);
                        }
                    }
                    parameters = new object[] {parse[2], parse[3]};
                    break;
                case "action":
                    receiver = bot;
                    parameters = new object[] { parse[1], parse[2]};
                    break;
            }

            if (receiver == null)
            {
                Console.WriteLine("Invalid command: '{0}'", parse[0]);
            }

            return new EngineCommand(receiver, parameters);
        }

        public void Dispose()
        {
        }
    }
}
