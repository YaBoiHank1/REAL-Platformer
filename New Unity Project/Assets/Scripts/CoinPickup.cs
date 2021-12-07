using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    //[SerializeField] AudioClip CoinPickupSFX;
    [SerializeField] int CoinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<GameSession>().AddToScore(CoinValue);
        Destroy(gameObject);

    }
}
