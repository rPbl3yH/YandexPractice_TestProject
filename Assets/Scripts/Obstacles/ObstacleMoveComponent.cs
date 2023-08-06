using UnityEngine;

public class ObstacleMoveComponent : MonoBehaviour
{
    public void Construct(float startPointY, float targetPointY)
    {
        print($"start point y {startPointY}, second point y {targetPointY}");        
    }
}