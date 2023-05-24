using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

namespace UserControlSystem.CommandsRealization
{
    public class ProduceUnitCommand: IProduceUnitCommand
    {
        public GameObject UnityPrefab => _unityPrefab;
        [InjectAsset("Chomper")] private GameObject _unityPrefab;
    }
}