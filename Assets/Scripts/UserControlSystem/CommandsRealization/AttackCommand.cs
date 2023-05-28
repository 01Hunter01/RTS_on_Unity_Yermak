using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class AttackCommand: IAttackCommand
    {
        public GameObject Target { get; }

        public AttackCommand(GameObject target)
        {
            Target = target;
        }
    }
}