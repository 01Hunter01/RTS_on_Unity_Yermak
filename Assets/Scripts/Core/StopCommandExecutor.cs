using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            command.Stop();
            Debug.Log("I am holding this position...");
        }
    }
}