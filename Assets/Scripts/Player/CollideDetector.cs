using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDetector : MonoBehaviour
{
    public event Action OnCollide;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("OnTriggerEnter");
        if (other.TryGetComponent(out CollideComponent collideComponent))
        {
            OnCollide?.Invoke();
        }
    }
}