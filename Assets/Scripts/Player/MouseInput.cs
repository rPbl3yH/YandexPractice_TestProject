using System;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public event Action OnMouseDown;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnMouseDown?.Invoke();
        }
    }
}