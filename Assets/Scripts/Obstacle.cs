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
        PlayerController target = GameObject.FindObjectOfType<PlayerController>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (target != null)
        {
            Vector2 moveDirection = (target.transform.position - transform.position).normalized * speed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

            //this picks a number between 1 and 2
            var rand = Random.Range(1, 3);
            if (rand == 1)
            {
                rotateRate = -1;
            }
            else
            {
                rotateRate = 1;
            }
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
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
