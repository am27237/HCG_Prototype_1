using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    SpriteRenderer sprite;

    void Start()
    {
        PlayerController target = GameObject.FindObjectOfType<PlayerController>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);


        sprite = GetComponent<SpriteRenderer>();
        // Default white color
        //sprite.color = new Color(1, 1, 1, 1);
    }

    private void Update()
    {
        //sprite.color = new Color(31, 255, 0, 255);
    }

    void GreenColor()
    {
        sprite.color = new Color(0, 1, 0, 1);
    }

    void WhiteColor()
    {
        sprite.color = new Color(1, 1, 1, 1);
    }
}
