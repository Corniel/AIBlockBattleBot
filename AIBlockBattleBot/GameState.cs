using System;
using AIBlockBattleBot.Commands;

namespace AIBlockBattleBot
{
    class GameState : EngineCommandReceiver
    {
        public int Round { get; set; }
        public PieceType PieceType { get; set; }
        public PieceType NextPieceType { get; set; }
        public int PiecePositionX { get; set; }
        public int PiecePositionY { get; set; }

        public GameState()
        {
            RouteCommand<GameStateCommand>(ReceiveCommand);
        }

        public void ReceiveCommand(GameStateCommand command)
        {
            switch (command.Key)
            {
                case "round":
                    Round = int.Parse(command.Value);
                    break;
                case "this_piece_type":
                {
                    PieceType pieceType;
                    PieceType = Enum.TryParse(command.Value, out pieceType) ? pieceType : PieceType.None;
                    break;   
                }
                case "next_piece_type":
                {
                    PieceType pieceType;
                    NextPieceType = Enum.TryParse(command.Value, out pieceType) ? pieceType : PieceType.None;
                    break;
                }
                case "this_piece_position":
                    var parse = (command.Value).Split(',');
                    PiecePositionX = int.Parse(parse[0]);
                    PiecePositionY = int.Parse(parse[1]);
                    break;
                default:
                    Console.WriteLine("Invalid game state command: {0}", command.Key);
                    break;
            }
        }
    }
}
