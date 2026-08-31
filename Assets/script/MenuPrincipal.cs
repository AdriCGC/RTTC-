using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string NomeDoLevel;
    [SerializeField] private GameObject PainelMenuInicial;
    [SerializeField] private GameObject painelOptions;
    public Fade FadeEffect;

    public void Start()
    {
        painelOptions.SetActive(false);
        StartCoroutine(FadeEffect.FadeInEffect());
    }

    public void Jogar ()
    {
        StartCoroutine(IniciarJogo());
    }

    IEnumerator IniciarJogo()
    {
        yield return StartCoroutine(FadeEffect.FadeOutEffect());
        SceneManager.LoadScene(NomeDoLevel);
    }

    public void AbrirOpcoes()
    {
        painelOptions.SetActive(true); 
    }

    public void FecharOpcoes()
    {
        // 👇 anima saída ao invés de desligar direto
        painelOptions.GetComponent<PopUpSnap>().Close();

        // volta menu principal
        PainelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        StartCoroutine(EncerrarJogo());
    }

    IEnumerator EncerrarJogo()
    {
        yield return StartCoroutine(FadeEffect.FadeOutEffect());
        Debug.Log("Saiu");
        Application.Quit();
    }
}