using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem.CommandCreators
{
    public sealed class MoveCommandCommandCreator: CommandCreatorBase<IMoveCommand>
    {
        [Inject] private AssetContext _context;
        protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new MoveCommand()));
        }
    }
}