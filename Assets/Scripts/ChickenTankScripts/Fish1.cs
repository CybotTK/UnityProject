using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish1 : MonoBehaviour
{
    public float speed = 2f; // Viteza peștelui
    public bool moveRight;  // Direcția de mișcare
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();

        // Setează direcția și scalarea peștelui
        if (moveRight)
        {
            tr.localScale = new Vector3(-0.15f, 0.15f, 1f); // Rotește peștele spre dreapta
        }
        else
        {
            tr.localScale = new Vector3(0.15f, 0.15f, 0.1f); // Spre stânga
        }
    }

    void FixedUpdate()
    {
        // Mișcă peștele pe orizontală
        float direction = moveRight ? 1f : -1f;
        tr.position += new Vector3(direction * speed * Time.deltaTime, 0f, 0f);

        // Distruge peștele dacă iese din ecran
        if (tr.position.x < -12f || tr.position.x > 12f)
        {
            Destroy(this.gameObject);
        }
    }
}
