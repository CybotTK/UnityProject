using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    float timer = 1;

    public GameObject[] gm;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;

        }

        else
        {
            int sansa = Random.Range(1, 101);
            float posX = Random.Range(-4.0f, 4.0f);

            if (sansa <= 50) // 50% șanse pentru primul obiect
            {
                Instantiate(gm[0], new Vector3(posX, 6.0f, 0.1f), Quaternion.identity); // Obiect 1
            }
            else if (sansa <= 75) // 25% șanse pentru al doilea obiect
            {
                Instantiate(gm[1], new Vector3(posX, 6.0f, 0.1f), Quaternion.identity); // Obiect 2
            }
            else if (sansa <= 90) // 15% șanse pentru al treilea obiect
            {
                Instantiate(gm[2], new Vector3(posX, 6.0f, 0.1f), Quaternion.identity); // Obiect 3
            }
            else // 10% șanse pentru al patrulea obiect
            {
                Instantiate(gm[3], new Vector3(posX, 6.0f, 0.1f), Quaternion.identity); // Obiect 4
            }
            timer = 0.7f;
        }
        
    }
}
