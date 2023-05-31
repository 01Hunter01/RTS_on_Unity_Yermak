using System;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core
{
    public class UnitMovementStop: MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {
        public class StopAwaiter: IAwaiter<AsyncExtensions.Void>
        {
            private readonly UnitMovementStop _unitMovementStop;
            private Action _continuation;
            private bool _isCompleted;

            public StopAwaiter(UnitMovementStop unitMovementStop)
            {
                _unitMovementStop = unitMovementStop;
                _unitMovementStop.OnStop += onStop;
            }

            private void onStop()
            {
                _unitMovementStop.OnStop -= onStop;
                _isCompleted = true;
                _continuation?.Invoke();
            }

            public void OnCompleted(Action contination)
            {
                if (_isCompleted)
                {
                    contination?.Invoke();
                }
                else
                {
                    _continuation = contination;
                }
            }

            public bool IsCompleted => _isCompleted;
            public AsyncExtensions.Void GetResult() => new AsyncExtensions.Void();
        }

        private event Action OnStop;

        [SerializeField] private NavMeshAgent _agent;

        private void Update()
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        OnStop?.Invoke();
                    }   
                }
            }
        }

        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
    }
}