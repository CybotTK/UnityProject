using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float destructionTime = 0f;
    [Range(0f, 1f)]
    public float itemSpawnChance = 0.2f;
    public GameObject[] spawnableItems;

    private void Start()
    {
        Destroy(gameObject, destructionTime);
    }
}