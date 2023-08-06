using System;
using App;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour, IGameUpdateListener
{
    public event Action<GameObject> OnSpawned;
     
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private int _countToSpawn = 2;
    [SerializeField] private float _delayToSpawn = 2f;
    private float _timer;

    public void OnUpdate(float deltaTime)
    {
        _timer += deltaTime;
        if (_timer >= _delayToSpawn)
        {
            _timer = 0f;
            Spawn();
        }
    }
    
    [ContextMenu("Spawn")]
    public void Spawn()
    {
        for (int i = 0; i < _countToSpawn; i++)
        {
            var gameObj = Instantiate(_obstacle);
            OnSpawned?.Invoke(gameObj);
        }
    }
}