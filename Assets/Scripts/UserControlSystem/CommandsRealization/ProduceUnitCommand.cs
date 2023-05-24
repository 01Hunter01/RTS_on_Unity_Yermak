using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class ProduceUnitCommand: IProduceUnitCommand
    {
        [SerializeField] private GameObject _unityPrefab;
        public GameObject UnityPrefab => _unityPrefab;
    }
}