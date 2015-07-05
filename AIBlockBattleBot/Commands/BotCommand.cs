namespace AIBlockBattleBot.Commands
{
    class BotCommand : EngineCommand
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public BotCommand(EngineCommandReceiver receiver, string key, string value)
            : base(receiver)
        {
            Key = key;
            Value = value;
        }
    }
}
