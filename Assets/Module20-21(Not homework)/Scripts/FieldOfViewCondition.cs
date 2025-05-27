using UnityEngine;

public class FieldOfViewCondition : IVisibilityCondition
{
    private Transform _sourceObject;
    private float _fieldOfViewDegree;

    public FieldOfViewCondition(Transform sourceObject, float fieldOfViewDegree)
    {
        _sourceObject = sourceObject;
        _fieldOfViewDegree = fieldOfViewDegree;
    }

    public bool IsCompleteFor(Transform target)
    {
        Vector3 directionToTarget = target.position - _sourceObject.position;

        float dotProduct = Vector3.Dot(directionToTarget, _sourceObject.forward);

        float cos = dotProduct / (directionToTarget.magnitude * _sourceObject.forward.magnitude);

        float angleToTarget = Mathf.Acos(cos) * Mathf.Rad2Deg;

        if (angleToTarget > _fieldOfViewDegree / 2)
            return false;

        return true;
    }
}
