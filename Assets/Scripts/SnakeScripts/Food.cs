using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        randomPosition();
    }

    void randomPosition()
    {
        int x = Random.Range(-8, 8);
        int y = Random.Range(-8, 8);
        transform.position = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        randomPosition();
        
    }
}
