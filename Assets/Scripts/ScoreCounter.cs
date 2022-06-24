using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int score;

    private void Start()
    {
        score = 0;
    }

    public void UpdateScore()
    {
        score++;
    }

    public int getScore()
    {
        return score;
    }
}
