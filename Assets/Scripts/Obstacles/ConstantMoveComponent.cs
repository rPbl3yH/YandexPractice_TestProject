using UnityEngine;

public class ConstantMoveComponent : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _finishBorderX = -5f;

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
        
        if (transform.position.x <= _finishBorderX)
        {
            Destroy(gameObject);
        }
    }
}