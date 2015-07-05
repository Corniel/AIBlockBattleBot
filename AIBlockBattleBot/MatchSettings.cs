using System;
using AIBlockBattleBot.Commands;

namespace AIBlockBattleBot
{
    class MatchSettings : EngineCommandReceiver
    {
        public int MaximumTimeBank { get; private set; }
        public int TimePerMove { get; private set; }
        public string[] PlayerNames { get; private set; }
        public string PlayerName { get; private set; }
        public int FieldWidth { get; private set; }
        public int FieldHeight { get; private set; }

        public MatchSettings()
        {
            RouteCommand<SettingsCommand>(ProcessCommand);
        }

        public void ProcessCommand(SettingsCommand command)
        {
            switch (command.Key)
            {
                case "time_bank":
                    MaximumTimeBank = int.Parse(command.Value);
                    break;
                case "time_per_move":
                    TimePerMove = int.Parse(command.Value);
                    break;
                case "player_names":
                    PlayerNames = (command.Value).Split(',');
                    break;
                case "your_bot":
                    PlayerName = command.Value;
                    break;
                case "field_width":
                    FieldWidth = int.Parse(command.Value);
                    break;
                case "field_height":
                    FieldHeight = int.Parse(command.Value);
                    break;
                default:
                    Console.WriteLine("Invalid match settings command: {0}", command.Key);
                    break;
            }
        }
    }
}
