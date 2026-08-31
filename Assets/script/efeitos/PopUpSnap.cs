using UnityEngine;
using DG.Tweening;

public class PopUpSnap : MonoBehaviour
{
    RectTransform rect;

    public float duration = 0.5f;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        // joga pra cima
        rect.anchoredPosition = new Vector2(0, 800f);

        // anima pro centro
        rect.DOAnchorPos(Vector2.zero, duration)
            .SetEase(Ease.OutBack)
            .SetUpdate(true);
    }
        public void Close()
    {
        // sobe antes de sumir
        rect.DOAnchorPos(new Vector2(0, 800f), duration)
            .SetEase(Ease.InBack)
            .SetUpdate(true)
            .OnComplete(() => gameObject.SetActive(false));
    }
}