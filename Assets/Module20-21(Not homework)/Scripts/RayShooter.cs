using UnityEngine;

public class RayShooter: IShooter
{
    private IShootEffect _shootEffect;

    public RayShooter(IShootEffect shootEffect)
    {
        _shootEffect = shootEffect;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        Ray ray = new Ray(origin, direction);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            _shootEffect.Execute(hit.point, hit.collider);
        }
    }
}
