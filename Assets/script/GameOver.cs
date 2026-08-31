using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public lucky Death;
    public GameObject TelaGameOver;

    public GerenciadorDeScore ScoreManager;
    public TMP_Text TextScoreFinal;
    public TMP_Text TextHighScore;
    public Fade FadeReturn;


    bool jaAtivou = false;

    void Update()
    {
        if (Death.Morte == true && !jaAtivou)
        {
            jaAtivou = true;
            StartCoroutine(MostrarGameOver());
        }
    }

    IEnumerator MostrarGameOver()
    {
        yield return new WaitForSeconds(1.5f);

        TelaGameOver.SetActive(true);
        Time.timeScale = 0f;

        ScoreManager.StopScore();
        ScoreManager.SalvarHighScore();

        int scoreFinal = ScoreManager.PegarScoreFinal();
        int highScore = ScoreManager.PegarMaiorScore();

        TextScoreFinal.text = "Score: " + scoreFinal;
        TextHighScore.text = "High Score: " + highScore;
    }

    public void ReiniciarJogo()
    {
        StartCoroutine(DelayReset());
    }

    IEnumerator DelayReset()
    {
        yield return StartCoroutine(FadeReturn.FadeOutEffect());

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}