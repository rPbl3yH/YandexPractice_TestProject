using System;
using App;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public event Action OnMouseUp;
    public event Action OnMouse;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnMouse?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp?.Invoke();
        }
    }
}