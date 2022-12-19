using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Upgrade/Atack"), InlineEditor]
public class AtackEnum : UpgradeEnum
{
    private enum AtackType
    {
        Damage,
        atackSpeed
    }

    [EnumToggleButtons, SerializeField] private AtackType atackType;

    protected override void UpgradeLogic()
    {
        switch (atackType)
        {
            case AtackType.Damage:
                Debug.Log($"Eski Damage {PlayerData.bulletDamage}");
                PlayerData.bulletDamage += PlayerData.bulletDamage * IncreaseRatio();
                Debug.Log($"Yeni Damage {PlayerData.bulletDamage}");
                break;
            case AtackType.atackSpeed:
                PlayerData.fireSpeed += PlayerData.fireSpeed * IncreaseRatio();
                break;
        }
    }
}