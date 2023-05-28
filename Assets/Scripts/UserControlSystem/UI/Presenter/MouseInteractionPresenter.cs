using System.Linq;
using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UserControlSystem
{
    public class MouseInteractionPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;
        [SerializeField] private EventSystem _eventSystem;

        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private Transform _groundTransform;

        [SerializeField] private AttackableValue _target;

        private Plane _groundPlane;

        private void Start()
        {
            _groundPlane = new Plane(_groundTransform.up, 0);
        }

        private void Update()
        {
            if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
            {
                return;
            }
            
            if (_eventSystem.IsPointerOverGameObject())
            {
                return;
            }

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonUp(0))
            {
                GetSelectableObject(ray);
            }
            else
            {
                GetPointForMove(ray);
                GetTargetForAttack(ray);
            }
        }

        private void GetSelectableObject(Ray ray)
        {
            var hits = Physics.RaycastAll(ray);
            if (hits.Length == 0)
            {
                return;
            }
            var selectable = hits
                .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                .FirstOrDefault(component => component != null);    
            _selectedObject.SetValue(selectable);
        }

        private void GetPointForMove(Ray ray)
        {
            if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue((ray.origin + ray.direction*enter));
            }
        }

        private void GetTargetForAttack(Ray ray)
        {
            var hits = Physics.RaycastAll(ray);
            if (hits.Length == 0)
            {
                return;
            }
            
            var attackable = hits
                .Select(hit => hit.collider.GetComponentInParent<BoxCollider>())
                .FirstOrDefault(component => component != null);

            if (attackable != null)
            {
                _target.SetValue(attackable.gameObject);
            }
        }
    }
}
