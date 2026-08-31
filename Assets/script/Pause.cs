using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public lucky Death;
    public Fade FadeReturn;



    

    private bool paused = false;

    void Start()
    {
    HidePauseMenu();
    }
    void Update()
    {
            if (!CountdownStart.jogoIniciado)
        return;
        
        if(Death.gameOver == false){
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                OptionsMenu.SetActive(false);  

                 if(paused)
                 {
                    
                    HidePauseMenu();

                 }
            else
            {

            ShowPauseMenu();

            }
        }
        }

    }

private void ShowPauseMenu()
{
    paused = true;

    Time.timeScale = 0f;

    PauseMenu.SetActive(true);
}


private void HidePauseMenu()
{
    paused = false;

    StartCoroutine(UnpauseAfterAnimation());
}

IEnumerator UnpauseAfterAnimation()
{
    PauseMenu.GetComponent<PopUpSnap>().Close();

    yield return new WaitForSecondsRealtime(0.5f); // tempo da animação

    Time.timeScale = 1f; // 🔥 volta o jogo só depois
}

    public void BTN_Quit()
    {
        StartCoroutine(DelayReset());
    }
        IEnumerator DelayReset()
        {
            yield return StartCoroutine(FadeReturn.FadeOutEffect());
            Time.timeScale = 1f;
            SceneManager.LoadScene("menu");

        }
    public void Opcoes()
    {
        OptionsMenu.SetActive(true);
    }

    public void voltar()
    {
    OptionsMenu.GetComponent<PopUpSnap>().Close();
    }

    public void resume()
    {
        HidePauseMenu();
    }

}
