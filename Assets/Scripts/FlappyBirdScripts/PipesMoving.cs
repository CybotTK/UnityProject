using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMoving : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdgeOfScreen;

    private void Start()
    {
        leftEdgeOfScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; // Push it one unit further to go fully off screen
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    
        if (transform.position.x < leftEdgeOfScreen )
        {
            Destroy(gameObject);
        }
    }

}
