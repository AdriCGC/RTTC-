using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverBold : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IDeselectHandler
{
    public TextMeshProUGUI texto;

    void Start()
    {
        texto.text = texto.text.ToUpper();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        texto.fontStyle = FontStyles.Bold;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        texto.fontStyle = FontStyles.Normal;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        texto.fontStyle = FontStyles.Normal;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        texto.fontStyle = FontStyles.Normal;
    }
}