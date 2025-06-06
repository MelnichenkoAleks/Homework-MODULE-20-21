using UnityEngine;

public class ExplosionService
{
    private readonly float _boomRadius;
    private readonly float _boomForce;

    private readonly GameObject _boomEffectPrefab;

    public ExplosionService(float boomRadius, float boomForce, GameObject boomEffectPrefab)
    {
        _boomRadius = boomRadius;
        _boomForce = boomForce;
        _boomEffectPrefab = boomEffectPrefab;
    }

    public void CreateExplosion(Vector3 point)
    {
        if (_boomEffectPrefab != null)
            Object.Instantiate(_boomEffectPrefab, point, Quaternion.identity);

        var colliders = Physics.OverlapSphere(point, _boomRadius);

        foreach (var col in colliders)
        {
            if (col.TryGetComponent<IBoomable>(out var boomable))
            {
                boomable.OnBoom(point, _boomForce, _boomRadius);
            }
        }
    }
}
