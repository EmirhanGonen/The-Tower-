public static class PlayerData 
{
    public static float maxHealth = 30.00f;

    public static float Health { get => health; set { health = value; UIManager.Instance.SetPlayerHealthBar(); } }
    private static float health;


    public static float fireSpeed = .30f;

    public static float bulletDamage = 5.00f;
    public static float bulletSpeed = 10.00f;


    public static double Coin { get => coin; set { coin = value; UIManager.Instance.SetText(); } }

    private static double coin = 0.00f;


    public static void Initalize()
    {
        Health = maxHealth;
        fireSpeed = .30f;
        bulletDamage = 5.00f;
        bulletSpeed = 10.00f;
        Coin = 0.00f;
    }
}