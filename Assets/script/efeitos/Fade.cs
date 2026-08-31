using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class Fade : MonoBehaviour
{
public Image FadeImage;
public GameObject FadeObject;



    public IEnumerator FadeOutEffect()
    {
        FadeObject.SetActive(true);

        float tempo = 0;

        Color cor = FadeImage.color;

        while (tempo < 1)
        {
            tempo += Time.unscaledDeltaTime;

            cor.a = tempo;
            FadeImage.color = cor;

            yield return null;
        }

    }
public IEnumerator FadeInEffect()
{
    FadeObject.SetActive(true);

    float tempo = 1;

    Color cor = FadeImage.color;

    cor.a = 1f;
    FadeImage.color = cor;

    while (tempo > 0)
    {
        tempo -= Time.unscaledDeltaTime;

        cor.a = tempo;
        FadeImage.color = cor;

        yield return null;
    }

    cor.a = 0;
    FadeImage.color = cor;

    FadeObject.SetActive(false);
}
}
