using UnityEngine;


public class AtackState : State, IGiveDamagable
{
    private ObstacleData obstacleData;

    private bool isFirstAtack = true;
    public override State RunCurrentState(ObstacleData data)
    {
        transform.GetComponentInParent<SpriteRenderer>().material.color = Color.red;
        if (!IsInvoking(nameof(Atack)) & isFirstAtack) { obstacleData = data; Invoke(nameof(Atack), 0.00f); isFirstAtack = false; /* çünkü ilk deðdiði an bekelemeden saldýrcak */ }

        return this;
    }

    public void Atack()
    {
        GiveDamage(obstacleData.target.GetComponentInChildren<IDamagable<float>>());
        if (!IsInvoking(nameof(Atack))) Invoke(nameof(Atack), obstacleData.atackSpeed);
    }

    public void GiveDamage<T>(T obstacle) where T : IDamagable<float>
    {
        obstacle.TakeDamage(obstacleData.damage);
    }
}