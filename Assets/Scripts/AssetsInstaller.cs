using System;
using Abstractions;
using UnityEngine;
using UserControlSystem;
using Utils;
using Zenject;

[CreateAssetMenu(fileName = "AssetsInstaller", menuName = "Installers/AssetsInstaller")]
public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
{
    [SerializeField] private AssetContext _legacyContext;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private SelectableValue _selectables;
    [SerializeField] private AttackableValue _attackablesRMB;
    [SerializeField] private Sprite _chomperSprite;
    
    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _groundClicksRMB, _selectables, _attackablesRMB);
        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_attackablesRMB);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_groundClicksRMB);

        Container.Bind<IObservable<ISelectable>>().FromInstance(_selectables);

        Container.Bind<Sprite>().WithId("Chomper").FromInstance(_chomperSprite);
    }
}