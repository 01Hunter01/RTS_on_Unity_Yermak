using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public sealed class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable, IAttackable
    {
        [SerializeField] private Transform _unitsParent;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;

        private float _health = 1000;
        
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Transform PivotPoint => _pivotPoint;
        
        
        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnityPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
                Quaternion.identity, _unitsParent);
        }

    }
}
