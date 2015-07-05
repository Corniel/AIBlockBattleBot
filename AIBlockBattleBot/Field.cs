using System;

namespace AIBlockBattleBot
{
    class Field
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public FieldCell[,] Grid { get; private set; }

        public Field(int width, int height)
        {
            Width = width;
            Height = height;

            Grid = new FieldCell[width, height];
        }

        public void Parse(string value)
        {
            var rows = value.Split(';');
            if (rows.Length != Height)
            {
                Console.WriteLine("Invalid player field: The number of given rows ({0}) does not match the field height ({1}).", rows.Length, Height);
                return;
            }
            for (var y = 0; y < Height; y++)
            {
                var cells = rows[y].Split(',');
                if (cells.Length != Width)
                {
                    Console.WriteLine("Invalid player field: The number of given cells ({0}) for row {1} does not match the field width ({2}).", rows.Length, y, Height);
                    return;
                }
                for (var x = 0; x < Width; x++)
                {
                    Grid[x, y] = new FieldCell(this, x, y, (FieldCellType)Enum.Parse(typeof(FieldCellType), cells[x]));
                }
            }
        }
    }
}
