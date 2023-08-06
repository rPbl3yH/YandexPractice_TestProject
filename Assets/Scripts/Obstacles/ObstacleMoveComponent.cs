using System;
using UnityEngine;

public class ObstacleMoveComponent : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private float _topPointY;
    private float _bottomPointY;
    private bool _isMovingUp;
    
    public void Construct(float firstPointY, float secondPointY, float pointX)
    {
        if (firstPointY > secondPointY)
        {
            _topPointY = firstPointY;
            _bottomPointY = secondPointY;
        }
        else
        {
            _topPointY = secondPointY;
            _bottomPointY = firstPointY;
        }

        transform.position = new Vector3(pointX, _topPointY, 0f);
        print($"top pointY {firstPointY}, bottom pointY {secondPointY}");        
    }

    private void Update()
    {
        var direction = Vector3.up;
        
        if (_isMovingUp)
        {
            if (transform.position.y >= _topPointY)
            {
                _isMovingUp = false;
            }
        }
        else
        {
            direction = Vector3.down;
            if (transform.position.y <= _bottomPointY)
            {
                _isMovingUp = true;
            }
        }
        transform.position += direction * (_speed * Time.deltaTime);
    }
}