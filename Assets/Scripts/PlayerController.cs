using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    [SerializeField] float xRange = 1.8f;
    SpriteRenderer playerColor;

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
        float xControl = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = speed * xControl * Time.deltaTime;
        float xRaw = transform.position.x + xOffset;
        float xPosClamp = Mathf.Clamp(xRaw, -xRange, xRange);
        transform.position = new Vector3(xPosClamp, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer obstacleColor;
        obstacleColor = collision.GetComponent<SpriteRenderer>();

        if (obstacleColor.color == playerColor.color)
        {
            Debug.Log("Collided with bonus");
        }
        else
        {
            Debug.Log("Collided with obstacle");
        }
    }
}
