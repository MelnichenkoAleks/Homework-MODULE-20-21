using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCondition : IVisibilityCondition
{
    private Transform _sourceObject;
    private float _distance;

    public DistanceCondition(Transform sourceObject, float distance)
    {
        _sourceObject = sourceObject;
        _distance = distance;
    }

    public bool IsCompleteFor(Transform target)
    {
        if (Vector3.Distance(target.position, _sourceObject.position) <= _distance)
            return true;

        return false;
    }
}
