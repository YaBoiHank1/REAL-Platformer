using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int CoinValue = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var gameSession = FindObjectOfType<GameSession>() as GameSession;
       gameSession.AddToScore(CoinValue);
       Destroy(gameObject);       
    }
}
