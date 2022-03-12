using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    GameObject obstacle;
    [SerializeField] GameObject player;
    SpriteRenderer obstacleColor;
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

    public void SpawnObstacle()
    {
        
        // Spawn in random x-axis  
        float xPos = Random.Range(-2.3f, 2.3f);

        // Randomly spawn between 0.5f and 1f
        float spawnRate = Random.Range(0.5f, 1f);

        if (Time.time > nextSpawn)
        {
            obstacle = ObjectPool.SharedInstance.GetPooledObject();

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

            if (obstacle != null)
            {
                obstacle.transform.position = new Vector2(xPos, transform.position.y);
                obstacle.SetActive(true);
            }

            nextSpawn = Time.time + spawnRate;
        }
    }

    void GreenObstacle()
    {
        obstacleColor = obstacle.GetComponent<SpriteRenderer>();
        obstacleColor.color = new Color(0,1,0,1);
    }

    void WhiteObstacle()
    {
        obstacleColor = obstacle.GetComponent<SpriteRenderer>();
        obstacleColor.color = new Color(1, 1, 1, 1);
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

    public void SpawnPlayer()
    {
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
