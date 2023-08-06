using App;
using Game.Money;
using UnityEngine;

public class CollideObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
{
    [SerializeField] private CollideDetector _collideDetector;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private MoneyStorage _moneyStorage;
    
    public void OnGameStarted()
    {
        _collideDetector.OnCollide += OnCollide;
    }

    private void OnCollide(GameObject obj)
    {
        if (obj.GetComponent<CollideComponent>())
        {
            _gameManager.FinishGame();    
        }

        if (obj.GetComponent<MoneyComponent>())
        {
            _moneyStorage.AddMoney();
        }
    }

    public void OnGameFinished()
    {
        _collideDetector.OnCollide -= OnCollide;
    }
}