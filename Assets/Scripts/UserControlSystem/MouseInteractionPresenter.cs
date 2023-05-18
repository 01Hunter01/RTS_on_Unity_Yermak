using System.Linq;
using Core;
using UnityEngine;

namespace UserControlSystem
{
    public class MouseInteractionPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;


        private void Update()
        {
            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }
            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
            if (hits.Length == 0)
            {
                return;
            }
            var mainBuilding = hits.Select(hit => hit.collider.GetComponentInParent<MainBuilding>())
                .FirstOrDefault(c => c != null);
            if (mainBuilding == default)
            {
                return;
            }
            mainBuilding.ProduceUnit();
        }
    }
}
