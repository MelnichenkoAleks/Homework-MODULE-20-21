using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private const string TakeDamageTriggerKey = "TakeDamage";
    private const string IsDeadKey = "IsDead";

    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _bodyCollider;

    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Debug.LogError(damage);
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            _bodyCollider.enabled = false;
            _animator.SetBool(IsDeadKey, true);
            return;
        }

        _animator.SetTrigger(TakeDamageTriggerKey);
    }
}
