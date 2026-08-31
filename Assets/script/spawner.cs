using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles; // [0] = carro, [1] = caminhão
    public dificuldade difficultyManager;
public float minSpawnTime = 0.5f;
public float maxSpawnTime = 4f;

    private float nextSpawnTime;

    void Start()
    {
        SetRandomTime();
    }

    void Update()
    {
        if (!CountdownStart.jogoIniciado)
    return;
        nextSpawnTime -= Time.deltaTime;

        if (nextSpawnTime <= 0f)
        {
            SpawnObstacle();
            SetRandomTime();
        }
    }

void SpawnObstacle()
{
    float difficulty = difficultyManager.difficulty;

    int chance = Random.Range(0, 100);

    int truckChance = Mathf.Clamp((int)(difficulty * 10), 10, 50);

    if (chance < (100 - truckChance))
    {
        Instantiate(obstacles[0], transform.position, Quaternion.identity);
    }
    else
    {
        Instantiate(obstacles[1], transform.position, Quaternion.identity);
    }
}

void SetRandomTime()
{
    float difficulty = difficultyManager.difficulty;

    float baseTime = Random.Range(minSpawnTime, maxSpawnTime);

    float randomOffset = Random.Range(-0.5f, 0.5f);

    float finalTime = baseTime + randomOffset - (difficulty * 0.2f);

    nextSpawnTime = Mathf.Max(0.3f, finalTime);
}
}