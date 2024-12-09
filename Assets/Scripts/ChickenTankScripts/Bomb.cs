using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 2f; // Viteza de mișcare
    public bool moveRight;  // Direcția de mișcare
    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();

        // Setează direcția și scalarea bombei
        if (moveRight)
        {
            tr.localScale = new Vector3(-1f, 1f, 1f); // 
        }
        else
        {
            tr.localScale = new Vector3(1f, 1f, 1f); // 
        }
    }

    void FixedUpdate()
    {
        // Mișcă bomba pe orizontală
        float direction = moveRight ? 1f : -1f;
        tr.position += new Vector3(direction * speed * Time.deltaTime, 0f, 0f);

        // Distruge bomba dacă iese din ecran
        if (tr.position.x < -12f || tr.position.x > 12f)
        {
            Destroy(this.gameObject);
        }
    }
}
