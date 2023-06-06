using System;
using Abstractions;
using UniRx;
using UnityEngine;
using Zenject;

namespace UserControlSystem
{
    public class OutlinePresenter: MonoBehaviour
    {
        [Inject] private IObservable<ISelectable> _selectedValues;

        private OutlineSelectorView[] _outlineSelectors;
        private ISelectable _currentSelectable;
        
        private void Start()
        {
            _selectedValues.Subscribe(OnSelectedOutline);
        }

        private void OnSelectedOutline(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            SetSelected(_outlineSelectors, false);
            _outlineSelectors = null;

            if (selectable != null)
            {
                _outlineSelectors = ((Component)selectable).GetComponentsInParent<OutlineSelectorView>();
                SetSelected(_outlineSelectors, true);
            }
            else
            {
                if (_outlineSelectors != null)
                {
                    SetSelected(_outlineSelectors, false);
                }
            }

            _currentSelectable = selectable;
        }

        private void SetSelected(OutlineSelectorView[] selectors, bool value)
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