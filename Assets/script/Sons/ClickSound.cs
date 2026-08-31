using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;

    private Button botao;

    void Start()
    {
        botao = GetComponent<Button>();

        botao.onClick.AddListener(TocarSom);
    }

    void TocarSom()
    {
        audioSource.PlayOneShot(clickSound);
    }
}