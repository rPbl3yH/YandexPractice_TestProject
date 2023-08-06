using System;
using UnityEngine;

public class CollideDetector : MonoBehaviour
{
    public event Action OnCollide;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CollideComponent>())
        {
            OnCollide?.Invoke();
        }
    }
}