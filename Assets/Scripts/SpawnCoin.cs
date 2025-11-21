using System;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private GameObject coin;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(coin, transform);
        }
    }
}
