using Abstractions;
using UnityEngine;

namespace Core
{
    public sealed class MainUnit: MonoBehaviour, ISelectable
    {
        [SerializeField] private float _maxHealh = 200;
        [SerializeField] private Sprite _icon;

        private float _health = 200;

        public float Health => _health;
        public float MaxHealth => _maxHealh;
        public Sprite Icon => _icon;
    }
}