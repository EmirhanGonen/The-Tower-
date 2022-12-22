using UnityEngine;



public class Obstacle : MonoBehaviour, IDamagable<float>
{
    [SerializeField] private ObstacleSO obstacleSO;

    public State currentState;

    private ObstacleData data;


    public delegate void OnDead();

    public OnDead onDead;

    public delegate void OnSpawn();

    public OnSpawn onSpawn;


    private bool isLive;

    private void OnEnable()
    {
        isLive = true;
        data = new();

        obstacleSO.SetVariables(data);
        Debug.Log(currentState.name);
    }
    private void OnDisable() => isLive = false;

    private void Update()
    {
        if (!isLive) return;

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
        onDead?.Invoke();

        ListHolder.Instance.damagables.Remove(this);

        PlayerData.Coin += data.loot;

        AnimateText(ObjectPooling.Instance.GetPooledObject<AnimatedCanvas>());

        gameObject.SetActive(false);
    }
    private void AnimateText(AnimatedCanvas canvas)
    {
        //UI managera taþý
        canvas.transform.position = transform.position;
        canvas.gameObject.SetActive(true);
        canvas.SetValue(data.loot);
    }
}