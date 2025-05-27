using UnityEngine;

public interface IVisibilityCondition 
{
    public bool IsCompleteFor(Transform target);
}
