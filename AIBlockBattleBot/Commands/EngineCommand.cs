namespace AIBlockBattleBot.Commands
{
    class EngineCommand
    {
        public EngineCommandReceiver Receiver { get; internal set; }

        protected EngineCommand(EngineCommandReceiver receiver)
        {
            Receiver = receiver;
        }

        public void Execute()
        {
            Receiver.ReceiveCommand(GetType(), this);
        }
    }
}
