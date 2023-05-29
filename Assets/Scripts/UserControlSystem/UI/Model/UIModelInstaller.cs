using Abstractions.Commands.CommandsInterfaces;
using Zenject;
using UserControlSystem.CommandCreators;
using Utils;

namespace UserControlSystem
{
    public sealed class UIModelInstaller: MonoInstaller
    {
        [Inject] private ScriptableObjectValues _values;
        
        public override void InstallBindings()
        {
            Container.Bind<AssetContext>().FromInstance(_values.assetContext);
            Container.Bind<Vector3Value>().FromInstance(_values.vector3Value);
            Container.Bind<SelectableValue>().FromInstance(_values.selectableValue);
            Container.Bind<AttackableValue>().FromInstance(_values.attackableValue);

            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
                .To<ProduceUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>()
                .To<AttackCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>()
                .To<MoveCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>()
                .To<PatrolCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>()
                .To<StopCommandCommandCreator>().AsTransient();

            Container.Bind<CommandButtonsModel>().AsTransient();
        }
    }
}