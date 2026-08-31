using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class GerenciadorDeScore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float score;
    public float scoreSpeed = 10f;

    public TMP_Text scoreText;

    private bool isGameOver = false;




    void Update()
    {
         if (!CountdownStart.jogoIniciado)
        return;

         score += Time.deltaTime;
             if (isGameOver) return;

        score += scoreSpeed * Time.deltaTime;

        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }
    public int PegarScoreFinal()
    {
        return Mathf.FloorToInt(score);
    }

    public int PegarMaiorScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
public void SalvarHighScore()
{
    int scoreFinal = PegarScoreFinal();
    int highScore = PegarMaiorScore();

    if (scoreFinal > highScore)
    {
        PlayerPrefs.SetInt("HighScore", scoreFinal);
    }
}


    public void StopScore()
    {
        isGameOver = true;
    }
}
