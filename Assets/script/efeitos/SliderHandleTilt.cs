using UnityEngine;
using UnityEngine.UI;

public class SliderHandleTilt : MonoBehaviour
{
    public Slider slider;
    public RectTransform handle;

    [Header("Rotação")]
    public float maxRotation = 20f;

    [Header("Escala")]
    public float minScale = 0.8f;
    public float maxScale = 1.2f;

    void LateUpdate()
    {
        if (slider == null || handle == null) return;

        // Normaliza (0 → 1)
        float normalized = (slider.value - slider.minValue) / (slider.maxValue - slider.minValue);

        // Centraliza (-1 → 1)
        float centered = (normalized - 0.5f) * 2f;

        // 🔄 ROTAÇÃO (sem Lerp pra evitar atraso)
        float targetRotation = -centered * maxRotation;
        handle.localRotation = Quaternion.Euler(0, 0, targetRotation);

        // 🔍 ESCALA (baseada no valor do slider)
        float scale = Mathf.Lerp(minScale, maxScale, normalized);
        handle.localScale = new Vector3(scale, scale, scale);
    }
}