using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introducao : MonoBehaviour
{
    public Fade FadeEffect;

    
    void Start()
    {
        StartCoroutine(iniciandointro());
    }

    IEnumerator iniciandointro()
    {
        yield return StartCoroutine(FadeEffect.FadeInEffect());
        StartCoroutine(Cooldown());
    }


    IEnumerator Cooldown()
    {
    
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(FadeEffect.FadeOutEffect());
        SceneManager.LoadScene("menu");

    }
    void Update()
    {
        
    }
}
