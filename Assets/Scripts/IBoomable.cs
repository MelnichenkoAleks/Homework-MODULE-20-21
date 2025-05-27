using UnityEngine;

public interface IBoomable 
{
    void OnBoom(Vector3 boomPosition, float force, float radius);
}
