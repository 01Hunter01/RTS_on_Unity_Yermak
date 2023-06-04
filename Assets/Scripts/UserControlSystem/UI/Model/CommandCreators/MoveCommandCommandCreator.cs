using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using UnityEngine;

namespace UserControlSystem.CommandCreators
{
    public sealed class MoveCommandCommandCreator: 
        CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand CreateCommand(Vector3 argument) => 
            new MoveCommand(argument);
    }
}