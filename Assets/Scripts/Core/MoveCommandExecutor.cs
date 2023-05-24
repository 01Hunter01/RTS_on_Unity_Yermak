using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public class MoveCommandExecutor: CommandExecutorBase<IMoveCommand>
    {
        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            command.Move();
            Debug.Log("I am moving somewhere...");
        }
    }
}