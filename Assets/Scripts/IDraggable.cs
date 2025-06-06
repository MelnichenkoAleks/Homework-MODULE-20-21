using UnityEngine;

public interface IDraggable 
{
    void OnDragStart();
    void OnDragEnd();

    void SetPosition(Vector3 position);
}
