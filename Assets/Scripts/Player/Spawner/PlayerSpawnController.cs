using App;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour, IGameInitListener, IGameFinishListener
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _spawnPoint;

    public void OnGameInit()
    {
        SetDefaultPosition();
    }
    
    public void OnGameFinished()
    {
        SetDefaultPosition();
    }

    private void SetDefaultPosition()
    {
        _transform.position = _spawnPoint.position;
    }
}
