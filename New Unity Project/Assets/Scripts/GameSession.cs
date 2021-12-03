using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public int playerHealth = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddToHealth(int CoinValue)
    {
        playerHealth += CoinValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
