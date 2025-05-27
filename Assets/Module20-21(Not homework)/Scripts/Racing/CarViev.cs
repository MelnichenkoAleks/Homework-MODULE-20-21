using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarViev : MonoBehaviour
{
    [SerializeField] private Transform _leftFrontWheel;
    [SerializeField] private Transform _rightFrontWheel;
    [SerializeField] private Transform _body;

    [SerializeField] private float _maxWheelRotation;
    [SerializeField] private float _maxBodyTitl;

    [SerializeField] private float _rotateStep;

    [SerializeField] private CarEngine _engine;

    [SerializeField] private TrailRenderer _leftWheelTrail;
    [SerializeField] private TrailRenderer _rightWheelTrail;
    [SerializeField] private ParticleSystem _smokeEffect;

    private float _speedSmokeEffect = 3;
    private float _cornerSmokeEffect = 30;

    private void Update()
    {
        transform.position = _engine.Position - Vector3.up * 0.45f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _engine.CurrentOrientation.rotation, _rotateStep * Time.deltaTime);

        _leftFrontWheel.localRotation = Quaternion
            .RotateTowards(_leftFrontWheel.localRotation, Quaternion.Euler(0, _engine.RotationSide * _maxWheelRotation, 0),
            _rotateStep *Time.deltaTime);

        _rightFrontWheel.localRotation = Quaternion
    .RotateTowards(_rightFrontWheel.localRotation, Quaternion.Euler(0, _engine.RotationSide * _maxWheelRotation, 0),
    _rotateStep * Time.deltaTime);

        _body.localRotation = Quaternion.
            RotateTowards(_body.localRotation, Quaternion.Euler(0,0,_engine.RotationSide * _maxBodyTitl), _rotateStep * Time.deltaTime);

        bool isDrift = _engine.OnGround && _engine.Velosity.magnitude > _speedSmokeEffect && Vector3.Angle(_engine.Velosity, transform.forward) > _cornerSmokeEffect;

        PlayEffect();
        StopEffect();
    }

    private void PlayEffect()
    {
        _leftWheelTrail.emitting = true;
        _rightWheelTrail.emitting = true;

        if (_smokeEffect.isPlaying == false)
            _smokeEffect.Play();
    }

    private void StopEffect()
    {
        _leftWheelTrail.emitting = false;
        _rightWheelTrail.emitting = false;

        if (_smokeEffect.isPlaying)
            _smokeEffect.Stop();
    }
}
