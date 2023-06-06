using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IProduceUnitCommand: ICommand, IIconHolder
    {
        float ProductionTime { get; }
        GameObject UnityPrefab { get; }
        string UnitName { get; }
    }
}