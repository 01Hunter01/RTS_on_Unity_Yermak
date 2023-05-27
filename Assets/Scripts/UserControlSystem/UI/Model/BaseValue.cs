using System;
using UnityEngine;

namespace UserControlSystem
{
    public abstract class BaseValue<T>: ScriptableObject
    {
        public T CurrentValue { get; private set; }
        public event Action<T> OnChanged;

        public void SetValue(T value)
        {
            CurrentValue = value;
            OnChanged?.Invoke(value);
        }

    }
}