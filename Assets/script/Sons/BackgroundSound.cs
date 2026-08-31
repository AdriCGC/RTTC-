using UnityEngine;

public class MusicaLoop : MonoBehaviour
{
    private static MusicaLoop instance;
    private AudioSource audioSource;

    void Awake()
    {
        // impede duplicar música
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // pega o AudioSource automaticamente
        audioSource = GetComponent<AudioSource>();

        audioSource.loop = true;
        audioSource.Play();
    }
}