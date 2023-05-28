using System;
using System.Runtime.InteropServices;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem.CommandCreators
{
    public sealed class AttackCommandCommandCreator: CommandCreatorBase<IAttackCommand>
    {
        
        [Inject] private AssetContext _context;

        private Action<IAttackCommand> _creationCallback;

        [Inject]
        private void Init(AttackableValue targets)
        {
            targets.OnNewValue += onNewValue;
        }

        private void onNewValue(GameObject target)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(target)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
    }
}