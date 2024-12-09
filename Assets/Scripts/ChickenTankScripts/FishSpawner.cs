using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fish1Prefab;
    public GameObject fish2Prefab;
    public GameObject fish3Prefab;
    public GameObject fish4Prefab;
    public GameObject fish5Prefab;
    public GameObject bombPrefab;

    public float spawnInterval = 1.5f; // Timpul dintre spawn-uri
    public float bombSpawnChance = 0.1f; // 10% șansă de a spawna bomba

    void Start()
    {
        // Începe generarea de pești și bombe
        InvokeRepeating("SpawnEntity", 1f, spawnInterval);
    }

    void SpawnEntity()
    {
        // Determină dacă se generează o bombă
        if (Random.value < bombSpawnChance)
        {
            SpawnBomb();
            return;
        }

        // Dacă nu e bombă, generează un pește
        SpawnFish();
    }


    void SpawnFish()
    {
        // Alege un tip aleatoriu de pește
        int randomFish = Random.Range(0, 5);

        GameObject fishToSpawn = randomFish switch
        {
            0 => fish1Prefab,
            1 => fish2Prefab,
            2 => fish3Prefab,
            3 => fish4Prefab,
            _ => fish5Prefab,
        };

        // Alege o direcție aleatorie (stânga sau dreapta)
        bool moveRight = Random.Range(0, 2) == 0;

        // Setează poziția de spawn
        float spawnX = moveRight ? -12f : 12f; // Începe din stânga sau dreapta
        float spawnY = Random.Range(-4f, 4f); // Poziția pe verticală

        // Instanțiază peștele
        GameObject spawnedFish = Instantiate(fishToSpawn, new Vector3(spawnX, spawnY, 0f), Quaternion.identity);

        // Verifică și setează direcția peștelui
        if (spawnedFish.GetComponent<Fish1>() != null)
        {
            spawnedFish.GetComponent<Fish1>().moveRight = moveRight;
        }
        else if (spawnedFish.GetComponent<Fish2>() != null)
        {
            spawnedFish.GetComponent<Fish2>().moveRight = moveRight;
        }
        else if (spawnedFish.GetComponent<Fish3>() != null)
        {
            spawnedFish.GetComponent<Fish3>().moveRight = moveRight;
        }
        else if (spawnedFish.GetComponent<Fish4>() != null)
        {
            spawnedFish.GetComponent<Fish4>().moveRight = moveRight;
        }
        else if (spawnedFish.GetComponent<Fish5>() != null)
        {
            spawnedFish.GetComponent<Fish5>().moveRight = moveRight;
        }
    }

    void SpawnBomb()
    {
        // Poziția de spawn pe axa Y
        float spawnY = Random.Range(-4f, 4f);

        // Direcția aleatorie (stânga sau dreapta)
        bool moveRight = Random.Range(0, 2) == 0;

        // Poziția de spawn pe axa X
        float spawnX = moveRight ? -12f : 12f;

        // Instanțiază bomba
        GameObject spawnedBomb = Instantiate(bombPrefab, new Vector3(spawnX, spawnY, 0f), Quaternion.identity);

        // Setează direcția bombei
        Bomb bomb = spawnedBomb.GetComponent<Bomb>();
        if (bomb != null)
        {
            bomb.moveRight = moveRight;
        }
    }


}
