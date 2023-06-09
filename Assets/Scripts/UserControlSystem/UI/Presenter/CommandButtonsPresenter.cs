using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using UniRx;
using UnityEngine;
using UserControlSystem.UI.View;
using Zenject;

namespace UserControlSystem
{
    public sealed class CommandButtonsPresenter: MonoBehaviour
    {
        [SerializeField] private CommandButtonsView _view;

        [Inject] private CommandButtonsModel _model;
        [Inject] private IObservable<ISelectable> _selectedValues;
        
        private ISelectable _currentSelectable;

        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;
            
            _selectedValues.Subscribe(OnSelected);
        }

        private void OnSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            if (_currentSelectable != null)
            {
                _model.OnSelectionChanged();
            }
            
            _currentSelectable = selectable;
            _view.Clear();
            
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component)
                    .GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }
    }
}