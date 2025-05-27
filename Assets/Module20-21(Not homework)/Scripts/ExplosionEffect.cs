using UnityEngine;

public class ExplosionEffect : IShootEffect
{
    private DamageEffect _damage;

    private float _radius;

    public ExplosionEffect(DamageEffect damage, float radius)
    {
        _damage = damage;
        _radius = radius;
    }

    public void Execute(Vector3 point, Collider collider)
    {
        Collider[] targets = Physics.OverlapSphere(point, _radius);

        foreach (Collider target in targets)
        {
            _damage.Execute(target.transform.position, target);
        }
    }
}
