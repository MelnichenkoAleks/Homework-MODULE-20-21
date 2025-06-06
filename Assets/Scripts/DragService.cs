using UnityEngine;

public class DragService 
{
    private IDraggable _selectedObject;

    private Transform _selectedTransform;

    private Plane _dragPlane;

    private readonly float _dragHeightOffset;

    public DragService(float dragHeightOffset)
    {
        _dragHeightOffset = dragHeightOffset;
    }

    public void TrySelectObject(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<IDraggable>(out var draggable))
            {
                _selectedObject = draggable;
                _selectedTransform = hit.transform;
                _dragPlane = new Plane(Vector3.up, _selectedTransform.position);
                _selectedObject.OnDragStart();
            }
        }
    }

    public void DragObject(Ray ray)
    {
        if (_selectedObject == null || _selectedTransform == null)
            return;

        if (_dragPlane.Raycast(ray, out float distance))
        {
            Vector3 point = ray.GetPoint(distance);
            _selectedObject.SetPosition(point + Vector3.up * _dragHeightOffset);
        }
    }

    public void ReleaseObject()
    {
        _selectedObject?.OnDragEnd();
        _selectedObject = null;
        _selectedTransform = null;
    }
}
