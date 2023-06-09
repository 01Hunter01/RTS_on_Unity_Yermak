using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem.CommandCreators
{
    public class SetRallyPointCommandCreator: CancellableCommandCreatorBase<ISetRallyPointCommand, Vector3>
    {
        protected override ISetRallyPointCommand CreateCommand(Vector3 argument) => 
            new SetRallyPointCommand(argument);
    }
}