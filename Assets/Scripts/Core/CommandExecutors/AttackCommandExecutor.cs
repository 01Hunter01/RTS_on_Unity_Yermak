using System.Threading.Tasks;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public class AttackCommandExecutor: CommandExecutorBase<IAttackCommand>
    {
        public override async Task ExecuteSpecificCommand(IAttackCommand command)
        { 
            Debug.Log($"{name} is attacking {command.Target} " +
                    $"with {command.Target.Health}/{command.Target.MaxHealth} hp!");
        }
        
    }
}