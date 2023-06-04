using System;
using UnityEngine;
using Utils;

namespace UserControlSystem
{
    public abstract class ScriptableObjectValueBase<T>: ScriptableObject, IAwaitable<T>
    {
        public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
        {
            private readonly ScriptableObjectValueBase<TAwaited> _scriptableObjectValueBase;

            public NewValueNotifier(ScriptableObjectValueBase<TAwaited> scriptableObjectValueBase)
            {
                _scriptableObjectValueBase = scriptableObjectValueBase;
                _scriptableObjectValueBase.OnNewValue += onNewValue;
            }

            private void onNewValue(TAwaited obj)
            {
                _scriptableObjectValueBase.OnNewValue -= onNewValue;
                OnWaitFinish(obj);
            }
        }

        public T CurrentValue { get; private set; }
        public event Action<T> OnNewValue;

        public void SetValue(T value)
        {
            CurrentValue = value;
            OnNewValue?.Invoke(value);
        }

        public IAwaiter<T> GetAwaiter()
        {
            return new NewValueNotifier<T>(this);
        }

    }
}