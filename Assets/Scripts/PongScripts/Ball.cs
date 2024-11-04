using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public Vector3 StartPos;

    private Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        LaunchBall();

    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = StartPos;
        LaunchBall();
    }

    private void LaunchBall()
    {
        if (manager.IsGameActive()) 
        {
            float xDir = Random.Range(0, 2) == 0 ? -1 : 1;
            float yDir = Random.Range(0, 2) == 0 ? -1 : 1;
            rb.velocity = new Vector2(xDir, yDir) * speed;
        }
        else
        {
            rb.velocity = Vector2.zero; 
        }
    }

    
}
