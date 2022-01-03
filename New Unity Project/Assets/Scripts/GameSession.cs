using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    
    public int score;
    public Text scoreText;
    bool healthAdd;

    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddToScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
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
        scoreText.text = score.ToString();
    }
}
