using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainBuildingCommandQueue: MonoBehaviour, ICommandsQueue
    {
        [Inject] private CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
        [Inject] private CommandExecutorBase<ISetRallyPointCommand> _setRallyPointCommandExecutor;


        public void Clear() { }

        public async void EnqueueCommand(object command)
        {
            await _produceUnitCommandExecutor.TryExecuteCommand(command);
            await _setRallyPointCommandExecutor.TryExecuteCommand(command);
        }
    }
}