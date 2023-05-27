using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem.CommandCreators
{
    public sealed class ProduceUnitCommandCommandCreator : CommandCreatorBase<IProduceUnitCommand>
    {
        [Inject] private AssetContext _context;
        
        protected override void ClassSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
           creationCallback?.Invoke(_context.Inject(new ProduceUnitCommandHeir()));
        }
    }
}