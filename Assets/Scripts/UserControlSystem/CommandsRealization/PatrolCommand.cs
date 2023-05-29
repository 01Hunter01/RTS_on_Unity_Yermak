using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public sealed class PatrolCommand: IPatrolCommand
    {
        public Vector3 StartPoint { get; }
        public Vector3 EndPoint { get; }

        public PatrolCommand(Vector3 startPoint, Vector3 endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}