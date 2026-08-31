using UnityEngine;

public class SpawnPredios : MonoBehaviour
{
    public GameObject[] buildings; 
    public float spawnRate = 2.5f;

    private float timer;

    void Update()
    {
        if (dificuldade.instance == null) return;

        float difficulty = dificuldade.instance.difficulty;

        // tempo anda normal
        timer += Time.deltaTime;

        // tempo necessário diminui com dificuldade
        float tempoParaSpawn = spawnRate / difficulty;

        if (timer >= tempoParaSpawn)
        {
            SpawnBuilding();
            timer = 0f;
        }
    }

    void SpawnBuilding()
    {
        if (buildings.Length == 0) return;

        int index = Random.Range(0, buildings.Length);

        GameObject building = Instantiate(buildings[index], transform.position, Quaternion.identity);

        int randomHeight = Random.Range(8, 14);
        building.transform.localScale = new Vector3(4.5f, randomHeight, 1f);
    }
}