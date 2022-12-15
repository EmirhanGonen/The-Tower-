using DG.Tweening;
using TMPro;
using UnityEngine;


public class AnimatedCanvas : MonoBehaviour
{
    private TextMeshProUGUI childText;

    private Color childTextColor;

    private void Awake()
    {
        childText = GetComponentInChildren<TextMeshProUGUI>();
        childTextColor = childText.color;
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    private void OnEnable()
    {
        DoAnimate();
    }

    public void DoAnimate()
    {
        childText.DOFade(1, 0);

        transform.DOMoveY(transform.position.y + 0.1115f, 1f).SetEase(Ease.Linear);

        childText.DOFade(0, 1f).SetEase(Ease.Flash).OnComplete(() => { gameObject.SetActive(false); });
    }
    public void SetValue(double Loot)
    {
        childText.SetText($"+ {Loot:0}");
    }
}