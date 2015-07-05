namespace AIBlockBattleBot.Commands
{
    class SettingsCommand : EngineCommand
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public SettingsCommand(EngineCommandReceiver receiver, string key, string value) : base(receiver)
        {
            Key = key;
            Value = value;
        }
    }
}
