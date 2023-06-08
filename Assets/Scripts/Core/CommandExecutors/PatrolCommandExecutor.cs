using System.Threading.Tasks;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public class PatrolCommandExecutor: CommandExecutorBase<IPatrolCommand>
    {
        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} is patrolling from {command.StartPoint} to {command.EndPoint}!");
        }
    }
}