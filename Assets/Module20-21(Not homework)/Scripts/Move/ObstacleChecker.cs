using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;

    [SerializeField] private float _distanseCheck;

    public bool IsTouches() => Physics.CheckSphere(transform.position, _distanseCheck, _mask.value);
}
