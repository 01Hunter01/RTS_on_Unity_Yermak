using UnityEngine;
using Zenject;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = "ValueInstaller", menuName = "Installers/ValueInstaller")]
    public class ValueInstaller : ScriptableObjectInstaller<ValueInstaller>
    {
        public ScriptableObjectValues values;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScriptableObjectValues>().FromInstance(values).AsSingle();
        }
    }
}