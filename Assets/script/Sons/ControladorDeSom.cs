using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeSom : MonoBehaviour
{
    public Slider SliderMusica;
    public AudioSource musica;
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
        }

        float volumeSalvo = PlayerPrefs.GetFloat("MusicVolume");

        SliderMusica.value = volumeSalvo;

        musica.volume = volumeSalvo;
    }

    public void SetVolume()
    {
        musica.volume = SliderMusica.value;
        SaveVolume();
    }
    public void SaveVolume()
    {
        musica.volume = SliderMusica.value;

        PlayerPrefs.SetFloat("MusicVolume", SliderMusica.value);
    }

    public void CarregarAudio()
    {
        SliderMusica.value = PlayerPrefs.GetFloat("MusicVolume");
    }


}