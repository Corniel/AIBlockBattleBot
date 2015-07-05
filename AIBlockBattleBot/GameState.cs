using System;

namespace AIBlockBattleBot
{
    class GameState : IEngineCommandReceiver
    {
        public int Round { get; set; }
        public PieceType PieceType { get; set; }
        public PieceType NextPieceType { get; set; }
        public int PiecePositionX { get; set; }
        public int PiecePositionY { get; set; }

        public void ReceiveCommand(EngineCommand command)
        {
            var parameters = command.Parameters;

            switch ((string)parameters[0])
            {
                case "round":
                    Round = int.Parse((string)parameters[1]);
                    break;
                case "this_piece_type":
                {
                    PieceType pieceType;
                    PieceType = Enum.TryParse((string)parameters[1], out pieceType) ? pieceType : PieceType.None;
                    break;   
                }
                case "next_piece_type":
                {
                    PieceType pieceType;
                    NextPieceType = Enum.TryParse((string) parameters[1], out pieceType) ? pieceType : PieceType.None;
                    break;
                }
                case "this_piece_position":
                    var parse = ((string) parameters[1]).Split(',');
                    PiecePositionX = int.Parse(parse[0]);
                    PiecePositionY = int.Parse(parse[1]);
                    break;
                default:
                    Console.WriteLine("Invalid game state property: {0}", (string)parameters[0]);
                    break;
            }
        }
    }
}
