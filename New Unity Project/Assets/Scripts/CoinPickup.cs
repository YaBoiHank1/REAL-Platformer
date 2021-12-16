using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int CoinValue = 1;
    public AudioClip fleshFX;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var gameSession = FindObjectOfType<GameSession>() as GameSession;
       gameSession.AddToScore(CoinValue);
        AudioSource.PlayClipAtPoint(fleshFX, Camera.main.transform.position);
       Destroy(gameObject);       
    }
}
