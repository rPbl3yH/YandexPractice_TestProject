using App;
using UnityEngine;

public class CollideObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
{
    [SerializeField] private CollideDetector _collideDetector;
    [SerializeField] private GameManager _gameManager;
    
    public void OnGameStarted()
    {
        _collideDetector.OnCollide += OnCollide;
    }

    private void OnCollide()
    {
        _gameManager.FinishGame();    
    }

    public void OnGameFinished()
    {
        _collideDetector.OnCollide -= OnCollide;
    }
}