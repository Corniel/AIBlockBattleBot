namespace AIBlockBattleBot
{
    struct FieldCell
    {
        public Field Field { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public FieldCellType Type { get; set; }

        public bool IsOutOfBounds
        {
            get { return X >= Field.Width || X < 0 || Y >= Field.Height; }
        }

        public bool HasCollision
        {
            get { return Type == FieldCellType.Piece && Field != null && (Field.Grid[X, Y].Type == FieldCellType.Block || Field.Grid[X, Y].Type == FieldCellType.Solid); }
        }

        public FieldCell(Field field, int x, int y, FieldCellType type) : this()
        {
            Field = field;
            X = x;
            Y = y;
            Type = type;
        }

    }
}
