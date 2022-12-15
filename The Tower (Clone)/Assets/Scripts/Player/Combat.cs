using UnityEngine;

public class Combat : MonoBehaviour
{
    public static Combat Instance { get; private set; }

    [SerializeField] private Bullet bullet;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PlayerData.Initalize();
    }
    private void Shoot()
    {
        if (ListHolder.Instance.DamagablesCount <= 0) { CheckShoot(); return; };

        Bullet spawnedBullet = ObjectPooling.Instance.GetPooledObject<Bullet>();

        spawnedBullet.gameObject.SetActive(true);

        spawnedBullet.transform.position = transform.position;
        spawnedBullet.Launch(ListHolder.Instance.damagables[0]);

        CheckShoot();
    }

    public void CheckShoot()
    {
        if (ListHolder.Instance.DamagablesCount <= 0 | IsInvoking(nameof(Shoot))) return;
        Invoke(nameof(Shoot), PlayerData.fireSpeed);
    }
}