using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Obstacle")]
public class ObstacleSO : ScriptableObject
{
    public int health;
    public float speed;

    public float damage;
    public float atackSpeed;

    [MinMaxSlider(0, 100)] public Vector2Int lootRange;
    public float Loot => Random.Range(lootRange.x, lootRange.y);

    private Transform target;

    public void SetVariables<T>(T obstacle) where T : ObstacleData
    {
        obstacle.speed = speed;
        obstacle.health = health;

        obstacle.damage = damage;
        obstacle.atackSpeed = atackSpeed;

        obstacle.loot = Loot;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        obstacle.target = target;
    }


}