using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Money
{
    public class MoneyInitializer : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private ObjectSpawner _moneySpawner;
        [SerializeField] private float _highBorderY = 1.2f;
        [SerializeField] private float _lowBorderY = -1.2f;
        [SerializeField] private float _pointX = 5f;

        private void Start()
        {
            _moneySpawner.OnSpawned += OnSpawned;
        }

        private void OnSpawned(GameObject obj)
        {
            obj.transform.position = new Vector3(_pointX, Random.Range(_highBorderY, _lowBorderY), 0f);
            
            if (obj.TryGetComponent(out MoneyComponent moneyComponent))
            {
                moneyComponent.Construct(_playerTransform);
            }
        }
    }
}