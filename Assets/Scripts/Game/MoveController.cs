using App;
using UnityEngine;

public class MoveController : MonoBehaviour, IGameStartListener, IGameFinishListener, IGameUpdateListener
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private float _upGravityScale = 1f;
    [SerializeField] private float _normalGravityScale = 1f;
    private bool _isMoveRequired;
    

    public void OnGameStarted()
    {
        _mouseInput.OnMouse += OnMouse;
        _rigidbody.simulated = true;
    }

    public void OnGameFinished()
    {
        _mouseInput.OnMouse -= OnMouse;
        _rigidbody.simulated = false;
    }
    
    private void OnMouse()
    {
        _isMoveRequired = true;
    }

    public void OnUpdate(float deltaTime)
    {
        if (_isMoveRequired)
        {
            _rigidbody.gravityScale = -_upGravityScale;
            _isMoveRequired = false;
        }
        else
        {
            _rigidbody.gravityScale = _normalGravityScale;
        }
    }
}