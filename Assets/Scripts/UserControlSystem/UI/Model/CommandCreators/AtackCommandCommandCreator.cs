using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem.CommandCreators
{
    public sealed class AttackCommandCommandCreator: CommandCreatorBase<IAttackCommand>
    {
        
        [Inject] private AssetContext _context;
        
        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new AttackCommand()));
        }
    }
}