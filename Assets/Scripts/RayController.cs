using UnityEngine;

public class RayController : MonoBehaviour
{
    [SerializeField] private float _boomRadius;
    [SerializeField] private float _boomForce;

    [SerializeField] private GameObject _boomEffectPrefab;

    [SerializeField] private float _dragHeightOffset;

    private IDraggable _selectedObject;

    private Transform _selectedTransform;

    private Plane _dragPlane;


    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            SelectObject(ray);
        }

        if (Input.GetMouseButton(0) && _selectedObject != null && _selectedTransform != null)
        {
            DragObject(ray);
        }

        if (Input.GetMouseButtonUp(0) && _selectedObject != null)
        {
            ReleaseObject();
        }

        if (Input.GetMouseButtonDown(1) && _selectedObject == null)          
            CreateBoom(ray);
    }

    private void SelectObject(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var draggable = hit.collider.GetComponent<IDraggable>();

            if (draggable != null)
            {
                _selectedObject = draggable;
                _selectedTransform = hit.collider.transform;

                _dragPlane = new Plane(Vector3.up, _selectedTransform.position);

                _selectedObject.OnDragStart();
            }
        }
    }

    private void DragObject(Ray ray)
    {
        if (_dragPlane.Raycast(ray, out float distance))
        {
            Vector3 point = ray.GetPoint(distance);
            _selectedTransform.position = point + Vector3.up * _dragHeightOffset;
        }
    }

    private void ReleaseObject()
    {
        _selectedObject.OnDragEnd();
        _selectedObject = null;
        _selectedTransform = null;
    }

    private void CreateBoom(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 boomPoint = hit.point;

            if (_boomEffectPrefab != null)
                Instantiate(_boomEffectPrefab, boomPoint, Quaternion.identity);

            Collider[] colliders = Physics.OverlapSphere(boomPoint, _boomRadius);

            foreach (Collider collider in colliders)
            {
                IBoomable boomable = collider.GetComponent<IBoomable>();

                if (boomable != null)
                {
                    boomable.OnBoom(boomPoint, _boomForce, _boomRadius);
                }
            }
            Debug.Log($"Взрыв в точке {boomPoint} с радиусом {_boomRadius}");
        }
    }
}
