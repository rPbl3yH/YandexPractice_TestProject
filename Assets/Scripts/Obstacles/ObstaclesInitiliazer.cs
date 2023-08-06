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
    
    private void OnSpawned(GameObject obj)
    {
        if (obj.TryGetComponent(out ObstacleMoveComponent moveComponent))
        {
            var startPosition = new Vector2(_pointX, Random.Range(_lowBorderY, _highBorderY));
            var secondPosition = new Vector2(_pointX, Random.Range(_lowBorderY, _highBorderY));
            moveComponent.Construct(startPosition.y, secondPosition.y);
        }
    }
    
    public void OnGameFinished()
    {
        _objectSpawner.OnSpawned -= OnSpawned;
    }
}