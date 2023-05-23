using System.Collections.Generic;
using Abstractions;
using UnityEngine;

namespace UserControlSystem
{
    public class OutlinePresenter: MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectedValue;

        private OutlineSelectorView[] _selectors;
        private ISelectable _currentSelectable;
        
        private void Start()
        {
            _selectedValue.OnSelected += OnSelectedOutline;
            OnSelectedOutline(_selectedValue.CurrentValue);
        }

        private void OnSelectedOutline(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            setSelected(_selectors, false);
            _selectors = null;

            if (selectable != null)
            {
                _selectors = ((Component)selectable).GetComponentsInParent<OutlineSelectorView>();
                setSelected(_selectors, true);
            }
            
        }

        private void setSelected(OutlineSelectorView[] selectors, bool value)
        {
           if(selectors != null)
           {
               for (int i = 0; i < selectors.Length; i++)
               {
                   selectors[i].SetSelected(value);
               }
           }
        }   
    }
}