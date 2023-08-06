using System;
using System.Collections.Generic;
using App;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour, IGameUpdateListener, IGameFinishListener
{
    public event Action<GameObject> OnSpawned;
     
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _countToSpawn = 2;
    [SerializeField] private float _delayToSpawn = 2f;

    private readonly List<GameObject> _gameObjects = new();
    
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
            var gameObj = Instantiate(_prefab);
            _gameObjects.Add(gameObj);
            OnSpawned?.Invoke(gameObj);
        }
    }

    public void OnGameFinished()
    {
        foreach (var gameObj in _gameObjects)
        {
            Destroy(gameObj);
        }
        
        _gameObjects.Clear();
    }
}