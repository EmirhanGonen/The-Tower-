using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumInitializer : MonoBehaviour
{
    public static EnumInitializer Instance { get; private set; }

    public List<UpgradeEnum> Upgrades = new();
    private void Awake()
    {
        Instance = this;
        foreach (UpgradeEnum upgrade in Upgrades) upgrade.InitializeVariables();
    }
}