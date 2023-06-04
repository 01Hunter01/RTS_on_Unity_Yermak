using System;
using Abstractions;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core
{
    public class TimeModel: ITimeModel, ITickable
    {
        public IObservable<int> GameTime { get; }

        private ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();
        
        public void Tick()
        {
            _gameTime.Value += Time.deltaTime;
        }
    }
}