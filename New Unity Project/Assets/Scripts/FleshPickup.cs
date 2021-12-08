using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshPickup : MonoBehaviour
{
    [SerializeField] int FleshValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<GameSession>().AddToScore(FleshValue);
        Destroy(gameObject);
    }
}
