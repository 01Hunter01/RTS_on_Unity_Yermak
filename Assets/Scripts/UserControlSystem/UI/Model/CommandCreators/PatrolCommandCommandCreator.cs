using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem.CommandCreators
{
    public sealed class PatrolCommandCommandCreator: CommandCreatorBase<IPatrolCommand>
    {
        [Inject] private AssetContext _context;
        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new PatrolCommand()));
        }
    }
}