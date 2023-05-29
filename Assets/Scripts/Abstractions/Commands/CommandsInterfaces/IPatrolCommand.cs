using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IPatrolCommand: ICommand
    {
        public Vector3 StartPoint { get; }
        public Vector3 EndPoint { get; }
    }
}