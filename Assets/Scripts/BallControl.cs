using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public GameObject Manager;
    private ScoreCounter scoreCounter;

    private void Start()
    {
        scoreCounter = Manager.GetComponent<ScoreCounter>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            scoreCounter.UpdateScore();
            Destroy(other.gameObject);
        }
    }

}
