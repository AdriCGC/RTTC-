using UnityEngine;

public class caminhao : MonoBehaviour
{
    public float velocidadeBase = 4.5f;
    public float lifeTime = 5f;
    float velocidadeFinal;



    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (lucky.instance != null && lucky.instance.Morte)
            return;

        velocidadeFinal = velocidadeBase + dificuldade.instance.difficulty;

        transform.Translate(Vector2.left * velocidadeFinal * Time.deltaTime);
        
    }
}