using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    main main;

    void Start()
    {
        main = GameObject.Find("scripts").GetComponent<main>();
    }

    private void FixedUpdate()
    {
        if (main.GameOver) return; // Nu continuăm dacă jocul este deja încheiat

        transform.position -= new Vector3(0f, 0.12f, 0f);

        if (transform.position.y < -7f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (main.GameOver) return; // Dacă e deja GameOver, nu face nimic

        if (collision.gameObject.name == "cyanChicken")
        {
            main.EndGame("Red Chicken");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "redChickenFlip")
        {
            main.EndGame("Cyan Chicken");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
