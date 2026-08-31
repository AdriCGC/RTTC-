using UnityEngine;

public class predios : MonoBehaviour
{
    public float velocidadeBase = 1f;
    public float lifeTime = 10f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
          if (lucky.instance != null && lucky.instance.Morte)
                return;

        float velocidadeFinal = velocidadeBase * dificuldade.instance.difficulty;

        transform.Translate(Vector2.left * velocidadeFinal * Time.deltaTime);
    }
}