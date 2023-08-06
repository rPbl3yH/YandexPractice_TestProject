using System;
using UnityEngine;

public class CollideDetector : MonoBehaviour
{
    public event Action<GameObject> OnCollide;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnCollide?.Invoke(other.gameObject);
    }
}