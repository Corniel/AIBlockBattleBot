using System;
using System.Collections.Generic;

namespace AIBlockBattleBot.Commands
{
    abstract class EngineCommandReceiver
    {
        private readonly Dictionary<Type, Action<EngineCommand>> _mappings; 

        protected EngineCommandReceiver()
        {
            _mappings = new Dictionary<Type, Action<EngineCommand>>();
        }

        protected void RouteCommand<T>(Action<T> action) where T : EngineCommand
        {
            _mappings.Add(typeof (T), command => action((T)command));
        }

        public void ReceiveCommand(Type commandType, EngineCommand command)
        {
            Action<EngineCommand> action;
            if (_mappings.TryGetValue(commandType, out action))
            {
                action(command);
            }
            else
            {
                //TODO: Throw exception.
            }
        }
    }
}
