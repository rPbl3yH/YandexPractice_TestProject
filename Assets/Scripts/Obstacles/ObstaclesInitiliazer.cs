using App;
using UnityEngine;

public class ObstaclesInitiliazer : MonoBehaviour, IGameStartListener, IGameFinishListener
{
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private float _highBorderY = 4f;
    [SerializeField] private float _lowBorderY = -3f;
    [SerializeField] private float _pointX = 5f;
    
    public void OnGameStarted()
    {
        _objectSpawner.OnSpawned += OnSpawned;
    }
    
    private void OnSpawned(GameObject gameObj)
    {
        if (gameObj.TryGetComponent(out ObstacleMoveComponent moveComponent))
        {
            var startPosition = Random.Range(_lowBorderY, _highBorderY);
            var secondPosition = Random.Range(_lowBorderY, _highBorderY);
            moveComponent.Construct(startPosition, secondPosition, _pointX);
        }
    }
    
    public void OnGameFinished()
    {
        _objectSpawner.OnSpawned -= OnSpawned;
    }
}