using UnityEngine;

public class Item : MonoBehaviour, IDraggable, IBoomable
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_rigidbody == null)
            Debug.LogError($"На {gameObject.name} не найден Rigidbody!");
    }
    public void OnDragEnd()
    {
        Debug.Log($"{gameObject.name} поднят");
    }

    public void OnDragStart()
    {
        Debug.Log($"{gameObject.name} отпущен");
    }

    public void OnBoom(Vector3 boomPosition, float force, float radius)
    {
        _rigidbody.AddExplosionForce(force, boomPosition, radius);
        Debug.Log($"{gameObject.name} получил взрыв");
    }

    public void SetPosition(Vector3 position)
    {
        _rigidbody.MovePosition(position);
    }
}