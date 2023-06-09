using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem.CommandCreators
{
    public sealed class AttackCommandCommandCreator: 
        CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand CreateCommand(IAttackable argument) => 
            new AttackCommand(argument);
    }
}