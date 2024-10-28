using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKey("right") == true)
        {
            if(tr.position.x < 4f)
            {
                tr.position += new Vector3(0.2f, 0, 0);
            }
        }

        if (Input.GetKey("left") == true)
        {
            if (tr.position.x > -4f)
            {
                tr.position += new Vector3(-0.2f, 0, 0);
            }
        }
    }
}
