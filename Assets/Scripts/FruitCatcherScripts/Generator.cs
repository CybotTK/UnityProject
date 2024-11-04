using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    float timer = 1f;
    public GameObject[] gm;
    private main main;

    void Start()
    {
        main = GameObject.Find("scripts")?.GetComponent<main>();
        if (main == null)
        {
            Debug.LogError("Referința la 'main' nu a fost găsită. Verifică numele obiectului 'scripts' în scenă.");
        }
    }

    void Update()
    {
        if (main != null && main.isGameActive) // Verificăm dacă jocul este activ
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                float posX = Random.Range(-4.0f, 4.0f);
                int sansa = Random.Range(1, 101);

                if (sansa <= 50)
                    Instantiate(gm[0], new Vector3(posX, 6.0f, 0.1f), Quaternion.identity); // Obiect 1
                else if (sansa <= 90)
                    Instantiate(gm[1], new Vector3(posX, 6.0f, 0.1f), Quaternion.identity); // Obiect 2
                else if (sansa <= 70)
                    Instantiate(gm[2], new Vector3(posX, 6.0f, 0.1f), Quaternion.identity); // Obiect 3
                else
                    Instantiate(gm[3], new Vector3(posX, 6.0f, 0.1f), Quaternion.identity); // Obiect 4

                timer = 0.7f;
            }
        }
    }
}
