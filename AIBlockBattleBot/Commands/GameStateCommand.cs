namespace AIBlockBattleBot.Commands
{
    class GameStateCommand : EngineCommand
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public GameStateCommand(EngineCommandReceiver receiver, string key, string value)
            : base(receiver)
        {
            Key = key;
            Value = value;
        }
    }
}
