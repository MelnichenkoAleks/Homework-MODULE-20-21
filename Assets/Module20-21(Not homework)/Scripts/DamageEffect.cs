using UnityEngine;

public class DamageEffect : IShootEffect
{
    private int _damage;

    public DamageEffect(int damage)
    {
        _damage = damage;
    }

    public void Execute(Vector3 point, Collider collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if (damageable != null)
            damageable.TakeDamage(_damage);
    }
}
