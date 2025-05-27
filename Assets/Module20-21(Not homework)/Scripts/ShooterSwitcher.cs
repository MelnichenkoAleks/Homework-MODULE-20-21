using UnityEngine;

public class ShooterSwitcher : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.SetShooter(new RayShooter(new DamageEffect(10)));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _player.SetShooter(new RayShooter(new DamageEffect(10)));

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _player.SetShooter(new RayShooter(new ExplosionEffect(new DamageEffect(20), 4)));
    }
}
