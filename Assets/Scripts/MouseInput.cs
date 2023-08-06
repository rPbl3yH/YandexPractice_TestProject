using System;
using App;
using UnityEngine;

public class MouseInput : MonoBehaviour, IGameUpdateListener
{
    public event Action OnMouseDown;

    public void OnUpdate(float deltaTime)
    {
        if (Input.GetMouseButton(0))
        {
            OnMouseDown?.Invoke();
        }
    }
}