using App;
using UnityEngine;

public class GameStarter : MonoBehaviour, IGameInitListener, IGameFinishListener
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private GameManager _gameManager;
    
    public void OnGameInit()
    {
        _mouseInput.OnMouseUp += OnMouseUp;
    }

    private void OnMouseUp()
    {
        _mouseInput.OnMouseUp -= OnMouseUp;
        _gameManager.StartGame();
    }

    public void OnGameFinished()
    {
        _mouseInput.OnMouseUp += OnMouseUp;
    }
}
