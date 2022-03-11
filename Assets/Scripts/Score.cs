using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreUI;
    int score;
    
    void Start()
    {
        scoreUI = GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    void Update()
    {
        scoreUI.text = "Score: " + score.ToString();
    }

    public void UpdateScore()
    {
        score = score + 1;
    }

}
