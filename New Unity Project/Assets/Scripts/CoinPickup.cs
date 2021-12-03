using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    //[SerializeField] AudioClip CoinPickupSFX;
    [SerializeField] int CoinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
<<<<<<< HEAD
        FindObjectOfType<PlatformerMovementWithFeet>().AddToHealth(CoinValue);
=======
        //FindObjectOfType<GameSession>().AddToScore(CoinValue);
        //AudioSource.PlayClipAtPoint(CoinPickupSFX, Camera.main.transform.position);
>>>>>>> 15846e30ab0003ac037c63bd588dcaa9dba47764
        Destroy(gameObject);

    }
}
