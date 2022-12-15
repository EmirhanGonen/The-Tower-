using System.Collections.Generic;
using UnityEngine;

public class ListHolder : MonoBehaviour
{
    public static ListHolder Instance { get; private set; }

    public List<Obstacle> damagables = new();
    public int DamagablesCount => damagables.Count;

    private void Awake()
    {
        Instance = this;
    }   
}