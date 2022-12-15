using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatCollisionDetect : MonoBehaviour
{
    public static PlayerCombatCollisionDetect Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Obstacle damagable)) return;
        ListHolder.Instance.damagables.Add(damagable);
        if (ListHolder.Instance.DamagablesCount <= 1) Combat.Instance.CheckShoot();
    }
}