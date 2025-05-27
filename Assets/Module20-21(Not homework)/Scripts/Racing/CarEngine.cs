using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speedForce;
    [SerializeField] private float _maxSpeed;

    [SerializeField] private Rigidbody _movable;
    [SerializeField] private Transform _currentOrientation;

    private float _distanceGround = 0.5f;
    private float _gravity = 9.81f;

    private float _horizontalInput;
    private float _verticalInput;

    private bool _onGround;

    public bool OnGround => _onGround;

    public Vector3 Velosity => _movable.velocity;

    public Vector3 Position => _movable.position;

    public Transform CurrentOrientation => _currentOrientation;

    public float RotationSide => _horizontalInput;

    private void Awake()
    {
        _movable.maxLinearVelocity = _maxSpeed;
    }

    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        _onGround = Physics.Raycast(_movable.position, Vector3.down, out RaycastHit groundHit, _distanceGround);

        if(_onGround)
        {
            Vector3 targetDirection = Vector3.Cross(_currentOrientation.right, groundHit.normal);
            _currentOrientation.rotation = Quaternion.LookRotation(targetDirection);
        }

        _currentOrientation.Rotate(Vector3.up * _horizontalInput * _rotationSpeed * Time.deltaTime, Space.Self);
    }

    private void FixedUpdate()
    {
        if (_onGround)
        {
            _movable.AddForce(_currentOrientation.forward * _speedForce * _verticalInput, ForceMode.Acceleration);

            if (_verticalInput <= 0.05f)
                _movable.velocity *= 0.95f;
        }
        else
        {
            _movable.AddForce(_currentOrientation.forward * _speedForce / 5, ForceMode.Acceleration);
            _movable.AddForce(Vector3.down * _gravity, ForceMode.Acceleration);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(_movable.position, _currentOrientation.right);

        Gizmos.color = Color.blue;
        Physics.Raycast(_movable.position, Vector3.down, out RaycastHit groundHit, _distanceGround);
        Gizmos.DrawRay(_movable.position, groundHit.normal);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(_movable.position, Vector3.Cross(_currentOrientation.right, groundHit.normal));
    }
}
