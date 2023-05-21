using System.Collections.Generic;
using Abstractions;
using UnityEngine;

namespace UserControlSystem
{
    public class OutlinePresenter: MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectedValue;
        [SerializeField] private List<GameObject> _prefabs;

        private void Start()
        {
            _selectedValue.OnSelected += OnSelectedOutline;
            OnSelectedOutline(_selectedValue.CurrentValue);
        }

        private void OnSelectedOutline(ISelectable selected)
        {
            foreach (var prefab in _prefabs)
            {
                var outline = prefab.GetComponent<Outline>();
                outline.enabled = selected != null;
            }
            
        }
    }
}