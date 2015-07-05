using System;

namespace AIBlockBattleBot
{
    class MatchSettings : IEngineCommandReceiver
    {
        public int MaximumTimeBank { get; private set; }
        public int TimePerMove { get; private set; }
        public string[] PlayerNames { get; private set; }
        public string PlayerName { get; private set; }
        public int FieldWidth { get; private set; }
        public int FieldHeight { get; private set; }

        public void ReceiveCommand(EngineCommand command)
        {
            var parameters = command.Parameters;
            switch ((string)parameters[0])
            {
                case "time_bank":
                    MaximumTimeBank = int.Parse((string) parameters[1]);
                    break;
                case "time_per_move":
                    TimePerMove = int.Parse((string) parameters[1]);
                    break;
                case "player_names":
                    PlayerNames = ((string) parameters[1]).Split(',');
                    break;
                case "your_bot":
                    PlayerName = (string) parameters[1];
                    break;
                case "field_width":
                    FieldWidth =  int.Parse((string) parameters[1]);
                    break;
                case "field_height":
                    FieldHeight =  int.Parse((string) parameters[1]);
                    break;
                default:
                    Console.WriteLine("Invalid match settings property: {0}", (string)parameters[0]);
                    break;
            }
        }
    }
}
