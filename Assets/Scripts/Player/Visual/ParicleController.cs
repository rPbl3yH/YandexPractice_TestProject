using System.Collections;
using System.Collections.Generic;
using App;
using UnityEngine;

public class ParicleController : MonoBehaviour, IGameStartListener, IGameFinishListener
{
    [SerializeField] private ParticleSystem _particleSystem;
    
    public void OnGameStarted()
    {
        _particleSystem.Play();
    }

    public void OnGameFinished()
    {
        _particleSystem.Stop();
        _particleSystem.Clear();
    }
}
