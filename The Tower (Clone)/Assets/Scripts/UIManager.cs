using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Image fillHealth;
    [SerializeField] private Image fillHealthBackGround;

    private void Awake()
    {
        Instance = this;
        SetText();
    }


    public void SetText()
    {
        coinText.SetText($"Coin: {PlayerData.Coin:0}");
    }

    public void SetPlayerHealthBar()
    {
        
        DOTween.To(() => fillHealth.fillAmount, X => fillHealth.fillAmount = X, PlayerData.Health / PlayerData.maxHealth, .30f)
            .OnComplete(() =>
            {
                DOTween.To(() => fillHealthBackGround.fillAmount, X => fillHealthBackGround.fillAmount = X, fillHealth.fillAmount, .30f);
            });

    }
}