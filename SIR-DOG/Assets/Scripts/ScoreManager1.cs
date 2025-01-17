using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager1 : MonoBehaviour
{
    public Text scoreText;
    public static int scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
    }

    public void AddScore(int points)
    {
        scoreCount += points;
    }
}

