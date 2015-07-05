namespace AIBlockBattleBot.Commands
{
    class PlayerCommand : EngineCommand
    {
        public string PlayerName { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public PlayerCommand(EngineCommandReceiver receiver, string playerName, string key, string value)
            : base(receiver)
        {
            PlayerName = playerName;
            Key = key;
            Value = value;
        }
    }
}
