using System;
using System.Linq;
using AIBlockBattleBot.Commands;

namespace AIBlockBattleBot
{
    class Parser : IDisposable
    {
        public EngineCommand PollCommand(Bot bot)
        {
            var line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
                return null;

            EngineCommand command = null;
            var parse = line.Split(' ');
            switch (parse[0])
            {
                case "settings":
                    command = new SettingsCommand(bot.MatchSettings, parse[1], parse[2]);
                    break;
                case "update":
                    if (parse[1] == "game")
                    {
                        command = new GameStateCommand(bot.GameState, parse[2], parse[3]);
                    }
                    else
                    {
                        if (bot.MatchSettings.PlayerNames.Contains(parse[1]))
                        {
                            if (!bot.Players.ContainsKey(parse[1]))
                            {
                                bot.Players.Add(parse[1], new PlayerState(bot.MatchSettings.FieldWidth, bot.MatchSettings.FieldHeight));
                            }

                            var player = bot.Players[parse[1]];
                            command = new PlayerCommand(player, parse[1], parse[2], parse[3]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid player: '{0}'", parse[1]);
                        }
                    }
                    break;
                case "action":
                    command = new BotCommand(bot, parse[1], parse[2]);
                    break;
            }

            if (command == null)
            {
                Console.WriteLine("Invalid command: '{0}'", parse[0]);
            }

            return command;
        }

        public void Dispose()
        {
        }
    }
}
