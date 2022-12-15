using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IGiveDamagable
{
    public void Launch(Obstacle obstacle) => StartCoroutine(nameof(Launch_CO), obstacle);

    private IEnumerator Launch_CO(Obstacle Obstacle)
    {
        Transform obstaclePosition = Obstacle.transform;
        while (Vector2.Distance(transform.position , obstaclePosition.position) > .2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, obstaclePosition.position, PlayerData.bulletSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IDamagable<float> damagable)) GiveDamage(damagable);
    }

    public void GiveDamage<T>(T obstacle) where T : IDamagable<float>
    {
        obstacle.TakeDamage(PlayerData.bulletDamage);
        gameObject.SetActive(false);
    }
}