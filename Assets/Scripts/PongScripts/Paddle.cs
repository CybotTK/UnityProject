using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed = 6f;
    public Rigidbody2D rb;
    public Vector3 StartPos;

    public float topLimit = 1f;  
    public float bottomLimit = -1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        StartPos = transform.position;
    }

    private void Update()
    {
        float moveInput = 0f;

        if (isPlayer1)
        {
            if (Input.GetKey(KeyCode.W) && transform.position.y < topLimit)
            {
                moveInput = 1f;
            }
            else if (Input.GetKey(KeyCode.S) && transform.position.y > bottomLimit)
            {
                moveInput = -1f;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < topLimit)
            {
                moveInput = 1f;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > bottomLimit)
            {
                moveInput = -1f;
            }
        }

        rb.velocity = new Vector2(0, moveInput * speed);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = StartPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle")) 
        {
            // Modifică direcția mingii în funcție de coliziune
            float yDir = Random.Range(0f, 1f) * (collision.transform.position.y > transform.position.y ? 1 : -1);
            rb.velocity = new Vector2(rb.velocity.x * -1, yDir).normalized * speed; // Schimbă direcția pe X și dă o nouă direcție pe Y
        }
    }
}
