using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    [SerializeField] float xRange = 1.8f;
    SpriteRenderer playerColor;
    [SerializeField] GameHandler gameHandler;   // Game handler reference
    [SerializeField] Score score;               // Score reference

    void Start()
    {
        // Assign green color
        // sprite.color = new Color (Red, Green, Blue, Alpha); // Choose between 1 and 0. Where, 1 is enabled, 0 disabled
        playerColor = GetComponent<SpriteRenderer>();
        playerColor.color = new Color(0, 1, 0, 1);
 
    }

    void Update()
    {
        MovementX();
    }

    private void MovementX()
    {
        // Player movement within X-Axis
        float xControl = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = speed * xControl * Time.deltaTime;
        float xRaw = transform.position.x + xOffset;
        float xPosClamp = Mathf.Clamp(xRaw, -xRange, xRange);   // player limitation movement on x-axis
        transform.position = new Vector3(xPosClamp, 0f, 0f);    // execute the movement
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Get the Sprite color of the obstacle
        SpriteRenderer obstacleColor;
        obstacleColor = collision.GetComponent<SpriteRenderer>();

        // If player and obstacle has the same color green then add score
        if (obstacleColor.color == playerColor.color)
        {
            score = FindObjectOfType<Score>();
            score.UpdateScore();
            collision.gameObject.SetActive(false);
        }

        // Inform game handler to stop the game and Destroy player and the obstacle collided
        else
        {
            gameHandler = FindObjectOfType<GameHandler>();
            gameHandler.GameIsPlaying(false);
            Destroy(gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
