using UnityEngine;

public class PaddleControlRight : MonoBehaviour
{
    public KeyCode controlKey = KeyCode.UpArrow;
    public float rotationAngle = 45f;

    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKey(controlKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        }
        else
        {
            transform.rotation = initialRotation;
        }
    }
}
