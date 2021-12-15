using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public int score;
    bool healthAdd;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //FindObjectOfType<DialougeTrigger>().TriggerDialouge();
        //FindObjectOfType<GameSession>().GetComponent<DialougeTrigger>().TriggerDialouge();
    }

    public void AddToScore(int points)
    {
        score += points;
        IncreaseHealth();
    }

    public void IncreaseHealth()
    {
        if (score == 5 || score == 10 || score == 15 || score == 20)
        {
            FindObjectOfType<PlatformerMovementWithFeet>().health++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
