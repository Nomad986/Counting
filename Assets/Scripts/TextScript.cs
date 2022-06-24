using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public GameObject Manager;
    private ScoreCounter scoreCounter;
    public Text scoreText;

    private void Start()
    {
        scoreCounter = Manager.GetComponent<ScoreCounter>();
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreCounter.getScore();
    }
}
