using Abstractions;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
    public sealed class SelectableValue: StatefulScriptableObjectValueBase<ISelectable>
    {
        
    }
}