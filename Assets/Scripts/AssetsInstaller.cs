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
    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _groundClicksRMB, _selectables, _attackablesRMB);
    }
}