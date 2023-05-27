using Abstractions;
using UnityEngine;

namespace UserControlSystem
{
    public class OutlinePresenter: MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectedValue;

        private OutlineSelectorView[] _outlineSelectors;
        private ISelectable _currentSelectable;
        
        private void Start()
        {
            _selectedValue.OnChanged += OnSelectedOutline;
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