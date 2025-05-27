using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private List<IVisibilityCondition> _visibilityConditions = new ();

    private void Awake()
    {
        // _fieldOfViewCondition = new FieldOfViewCondition(transform, 90);

        _visibilityConditions.Add(new FieldOfViewCondition(transform, 90));
        _visibilityConditions.Add(new DistanceCondition(transform, 4));
    }

    private void Update()
    {
        //if (_fieldOfViewCondition.IsCompleteFor(_target))
        //    _target.transform.localScale = new Vector3(2, 2, 2);
        //else
        //    _target.transform.localScale = new Vector3(1, 1, 1);

        foreach(IVisibilityCondition condition in _visibilityConditions)
        {
            if (condition.IsCompleteFor(_target) == false)
            {
                _target.transform.localScale = new Vector3(1, 1, 1);
                return;
            }
        }

        _target.transform.localScale = new Vector3(2, 2, 2);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, _target.position);
        Gizmos.DrawRay(transform.position, transform.forward * 100);
    }
}
