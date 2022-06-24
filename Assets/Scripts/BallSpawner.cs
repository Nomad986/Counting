using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    [SerializeField] private float spawnHeight = 8;
    [SerializeField] private float spawnRange;

    void Start()
    {
        StartCoroutine(Spawner());
    }
    
    IEnumerator Spawner()
    {
        for (int i = 0; i < 15; i++)
        {
            float randomX = Random.Range(-spawnRange, spawnRange);
            float randomZ = Random.Range(-spawnRange, spawnRange);
            Vector3 randomPosition = new Vector3(randomX, spawnHeight, randomZ);

            Instantiate(ballPrefab, randomPosition, ballPrefab.transform.rotation);

            yield return new WaitForSeconds(3f);
        }

    }
}
