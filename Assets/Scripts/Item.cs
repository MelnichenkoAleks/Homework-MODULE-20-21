using UnityEngine;

public class Item : MonoBehaviour, IDraggable, IBoomable
{
    private Rigidbody _rigibody;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody>();

        if (_rigibody == null)
            Debug.LogError($"�� {gameObject.name} �� ������ Rigidbody!");
    }
    public void OnDragEnd()
    {
        Debug.Log($"{gameObject.name} ������");
    }

    public void OnDragStart()
    {
        Debug.Log($"{gameObject.name} �������");
    }

    public void OnBoom(Vector3 boomPosition, float force, float radius)
    {
        _rigibody.AddExplosionForce(force, boomPosition, radius);
        Debug.Log($"{gameObject.name} ������� �����");
    }
}