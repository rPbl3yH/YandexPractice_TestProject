using System.Collections.Generic;
using UnityEngine;

namespace App
{
    public class GameManager : MonoBehaviour
    {
        public GameState GameState => _gameState;

        private GameState _gameState;
        private List<IGameListener> _listeners = new();
        private List<IGameUpdateListener> _updateListeners = new();
        private List<IGameFixedUpdateListener> _fixedUpdatesListeners = new();

        private void Update() {
            if (_gameState == GameState.Playing) {
                var deltaTime = Time.deltaTime;
            
                foreach (var updateListener in _updateListeners) {
                    updateListener.OnUpdate(deltaTime);
                }
            }
        }

        private void LateUpdate() {
            if(_gameState == GameState.Playing) {
                var deltaTime = Time.deltaTime;

                foreach(var updateListener in _fixedUpdatesListeners) {
                    updateListener.OnFixedUpdate(deltaTime);
                }
            }
        }

        public void AddListeners(IGameListener[] gameListeners) {
            foreach (var gameListener in gameListeners) {
                AddListener(gameListener);
            }
        }

        public void AddListener(IGameListener gameListener) {
            _listeners.Add(gameListener);

            if (gameListener is IGameUpdateListener gameUpdateListener) {
                _updateListeners.Add(gameUpdateListener);
            }

            if (gameListener is IGameFixedUpdateListener gameLateUpdateListener) {
                _fixedUpdatesListeners.Add(gameLateUpdateListener);
            }
        }

        [ContextMenu("Start game")]
        public void StartGame() {
            if(_gameState == GameState.Playing || _gameState == GameState.Paused) {
                return;
            }

            foreach (var gameListener in _listeners) {
                if (gameListener is IGameStartListener gameStartListener) {
                    gameStartListener.OnGameStarted();
                }
            }

            SetState(GameState.Playing);
        }

        public void FinishGame() {
            if(_gameState == GameState.Finished) {
                return;
            }

            foreach (var gameListener in _listeners) {
                if (gameListener is IGameFinishListener gameFinishListener) {
                    gameFinishListener.OnGameFinished();
                }
            }

            SetState(GameState.Finished);
        }
    
        private void SetState(GameState gameState) {
            _gameState = gameState;
            print($"Current game state = {gameState}");
        }
    }
}