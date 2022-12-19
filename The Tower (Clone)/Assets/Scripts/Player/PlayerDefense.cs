using UnityEngine;


public class PlayerDefense : MonoBehaviour, IDamagable<float>
{
    public void TakeDamage(float amount)
    {
        PlayerData.Health -= amount;
        PlayerData.Health = Mathf.Clamp(PlayerData.Health, 0, PlayerData.maxHealth);
        Debug.Log($"Damage Ald�m {PlayerData.Health} can�m kald�");
        if (PlayerData.Health > 0) return;
        Die();
    }
    public void Die()
    {
        Destroy(transform.parent.gameObject);
    }
}