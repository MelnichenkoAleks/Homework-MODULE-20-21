using UnityEngine;

public class Player : MonoBehaviour
{
    private IShooter _shooter;

    public void SetShooter(IShooter shooter) => _shooter = shooter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            _shooter.Shoot(ray.origin, ray.direction);
        }
    }
}
