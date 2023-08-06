using UnityEngine;

namespace App
{
    public class GameManagerInstaller : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;

        private void Awake() {
            var listeners = GetComponentsInChildren<IGameListener>();
            _gameManager.AddListeners(listeners);
        }
    }
}