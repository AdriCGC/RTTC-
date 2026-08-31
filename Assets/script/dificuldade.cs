using UnityEngine;

public class dificuldade : MonoBehaviour
{
    public static dificuldade instance;

    [Header("Configuração de Dificuldade")]
    public float difficulty = 1f;
    public float increaseRate = 0.05f;

    [Header("Limites")]
    public float maxDifficulty = 10f;

    void Awake()
    {
        // Garante que só existe um instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        IncreaseDifficulty();
    }

    void IncreaseDifficulty()
    {
        difficulty += increaseRate * Time.deltaTime;

        // Limita a dificuldade pra não ficar absurda
        difficulty = Mathf.Clamp(difficulty, 1f, maxDifficulty);
    }
}