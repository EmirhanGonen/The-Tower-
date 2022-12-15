
public interface IDamagable<T>
{
    public void TakeDamage(T amount);
    public void Die();
}

public interface IGiveDamagable
{
    public void GiveDamage<T>(T obstacle) where T : IDamagable<float>;
}