using System;
using AIBlockBattleBot.Commands;

namespace AIBlockBattleBot
{
    class PlayerState : EngineCommandReceiver
    {
        public int RowsPoints { get; set; }
        public int Combo { get; set; }
        public Field Field { get; set; }

        public PlayerState(int fieldWidth, int fieldHeight)
        {
            Field = new Field(fieldWidth, fieldHeight);

            RouteCommand<PlayerCommand>(ReceiveCommand);
        }

        public void ReceiveCommand(PlayerCommand command)
        {     
            switch (command.Key)
            {
                case "row_points":
                    RowsPoints = int.Parse(command.Value);
                    break;
                case "combo":
                    Combo = int.Parse(command.Value);
                    break;
                case "field":
                    Field.Parse(command.Value);
                    break;
                default:
                    Console.WriteLine("Invalid player command: {0}", command.Key);
                    break;
            }
        }
    }
}
