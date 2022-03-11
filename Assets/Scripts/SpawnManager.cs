using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    SpriteRenderer greenObstacle;
    [SerializeField] bool activateGreen = false;
    float nextSpawn;
    [SerializeField] GameHandler gameHandler;

    void Start()
    {
        nextSpawn = Time.time;
        StartCoroutine(ActivateGreenRoutine());
        gameHandler = gameHandler.GetComponent<GameHandler>();
    }

    private void Update()
    {
        if (gameHandler.GetGameOn() == true)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        // Spawn in random x-axis  
        float xPos = Random.Range(-2.3f, 2.3f);

        // Randomly spawn between 0.5f and 1f
        float spawnRate = Random.Range(0.5f, 1f);

        if (Time.time > nextSpawn)
        {
            if (activateGreen == false)
            {
                WhiteObstacle();
            }
            else
            {
                GreenObstacle();
                activateGreen = false;
                StartCoroutine(ActivateGreenRoutine());
            }
            Instantiate(obstaclePrefab, new Vector2(xPos, transform.position.y), Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
        }
    }

    void GreenObstacle()
    {
        greenObstacle = obstaclePrefab.GetComponent<SpriteRenderer>();
        greenObstacle.color = new Color(0,1,0,1);
    }

    void WhiteObstacle()
    {
        greenObstacle = obstaclePrefab.GetComponent<SpriteRenderer>();
        greenObstacle.color = new Color(1, 1, 1, 1);
    }

    void ActivateGreenObstacle()
    {
        activateGreen = true;
    }

    IEnumerator ActivateGreenRoutine()
    {
        float randomRate = Random.Range(1f, 4f);
        yield return new WaitForSeconds(randomRate);
        ActivateGreenObstacle();
    }
}
