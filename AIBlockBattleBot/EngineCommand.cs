namespace AIBlockBattleBot
{
    class EngineCommand
    {
        public IEngineCommandReceiver Receiver { get; internal set; }
        public object[] Parameters { get; internal set; }

        public EngineCommand(IEngineCommandReceiver receiver, params object[] parameters)
        {
            Receiver = receiver;
            Parameters = parameters;
        }

        public void Execute()
        {
            Receiver.ReceiveCommand(this);
        }
    }
}
