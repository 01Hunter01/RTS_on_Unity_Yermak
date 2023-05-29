using System;
using Utils;

namespace UserControlSystem
{
    [Serializable]
    public class ScriptableObjectValues
    {
        public AssetContext assetContext;
        public Vector3Value vector3Value;
        public SelectableValue selectableValue;
        public AttackableValue attackableValue;
    }
}