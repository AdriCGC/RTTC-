using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownStart : MonoBehaviour
{
    public static bool jogoIniciado = false;

    public GameObject painelPreto;
    public TextMeshProUGUI texto;
    public Fade FadeStart;
    
    

    void Start()
    {
        jogoIniciado = false;
        StartCoroutine(IniciarJogo());
    }
IEnumerator IniciarJogo()
    {
        yield return StartCoroutine(FadeStart.FadeInEffect());
        StartCoroutine(Contagem());
    }

    IEnumerator Contagem()
    {
        painelPreto.SetActive(true);

        yield return Mostrar("3");
        yield return Mostrar("2");
        yield return Mostrar("1");
        yield return Mostrar("GO!");

        painelPreto.SetActive(false);
        jogoIniciado = true;
    }

    IEnumerator Mostrar(string n)
    {
        texto.text = n;
        yield return new WaitForSeconds(1f);
    }
}