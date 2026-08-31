using UnityEngine;
using UnityEngine.UI;

public class ControladorDeSons : MonoBehaviour
{
    public Slider SliderSom;
    public AudioSource[] efeitosSonoros;

    void Start()
    {
        // Se não existir valor salvo
        if (!PlayerPrefs.HasKey("SoundVolume"))
        {
            PlayerPrefs.SetFloat("SoundVolume", 1);
        }

        // Carrega valor salvo
        float volumeSalvo = PlayerPrefs.GetFloat("SoundVolume");

        // Atualiza slider
        SliderSom.value = volumeSalvo;

        // Atualiza todos os efeitos
        foreach (AudioSource efeito in efeitosSonoros)
        {
            efeito.volume = volumeSalvo;
        }
    }

    public void SetSomVolume()
    {
        foreach (AudioSource efeito in efeitosSonoros)
        {
            efeito.volume = SliderSom.value;
        }

        SaveSEVolume();
    }

    public void SaveSEVolume()
    {
        PlayerPrefs.SetFloat("SoundVolume", SliderSom.value);
    }
}