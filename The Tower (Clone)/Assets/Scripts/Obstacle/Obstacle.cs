using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable<float>
{
    [SerializeField] private ObstacleSO obstacleSO;

    public State currentState;

    private ObstacleData data;

    private void Awake()
    {
        data = new();
        obstacleSO.SetVariables(data);
    }

    private void Update()
    {
        State nextState = currentState.RunCurrentState(data);

        if (nextState) SwitchToTheNextState(nextState);
    }
    private void SwitchToTheNextState(State nextState) => currentState = nextState;

    public void TakeDamage(float amount)
    {
        data.health -= amount;
        if (data.health > 0) return;
        Die();
    }
    public void Die()
    {
        ListHolder.Instance.damagables.Remove(this);
        PlayerData.Coin += data.loot;
        AnimateText(ObjectPooling.Instance.GetPooledObject<AnimatedCanvas>());
        Destroy(this.gameObject);
    }
    private void AnimateText(AnimatedCanvas canvas)
    {
        canvas.transform.position = transform.position;
        canvas.gameObject.SetActive(true);
        canvas.SetValue(data.loot);
    }
}