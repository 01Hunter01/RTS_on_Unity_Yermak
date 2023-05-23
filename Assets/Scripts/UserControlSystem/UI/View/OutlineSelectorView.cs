using UnityEngine;

namespace UserControlSystem
{
    public class OutlineSelectorView: MonoBehaviour
    {
        [SerializeField] private Outline _outlineScript;

        private bool _isSelectedCache;

        public void SetSelected(bool isSelected)
        {
            if (isSelected == _isSelectedCache)
            {
                return;
            }

            _outlineScript.enabled = isSelected;
            _isSelectedCache = isSelected;
        }
    }
}