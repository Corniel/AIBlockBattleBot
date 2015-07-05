using System;

namespace AIBlockBattleBot
{
    class PlayerState : IEngineCommandReceiver
    {
        public int RowsPoints { get; set; }
        public int Combo { get; set; }
        public Field Field { get; set; }

        public PlayerState(int fieldWidth, int fieldHeight)
        {
            Field = new Field(fieldWidth, fieldHeight);
        }

        public void ReceiveCommand(EngineCommand command)
        {     
            var parameters = command.Parameters;

            switch ((string)parameters[0])
            {
                case "row_points":
                    RowsPoints = int.Parse((string) parameters[1]);
                    break;
                case "combo":
                    Combo = int.Parse((string) parameters[1]);
                    break;
                case "field":
                    Field.Parse((string) parameters[1]);
                    break;
                default:
                    Console.WriteLine("Invalid player state property: {0}", (string)parameters[0]);
                    break;
            }
        }
    }
}
