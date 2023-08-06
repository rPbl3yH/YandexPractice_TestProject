using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private float _upGravityScale = 1f;
    [SerializeField] private float _downGravityScale = 1f;
    private bool _isMoveRequired;
    
    private void Start()
    {
        _mouseInput.OnMouseDown += OnMouseDown;
    }

    private void OnMouseDown()
    {
        _isMoveRequired = true;
    }

    private void Update()
    {
        if (_isMoveRequired)
        {
            _rigidbody.gravityScale = -_upGravityScale;
            _isMoveRequired = false;
        }
        else
        {
            _rigidbody.gravityScale = _downGravityScale;
        }
    }
}