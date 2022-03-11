using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    float rotateRate;

    private void OnEnable()
    {
        Invoke("DestroyMe", 3);
    }

    void Start()
    {
        PlayerController target = GameObject.FindObjectOfType<PlayerController>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (target != null)
        {
            Vector2 moveDirection = (target.transform.position - transform.position).normalized * speed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
            rotateRate = Random.Range(-1, 2);
        }
        else
            return;
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, rotateRate);
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
