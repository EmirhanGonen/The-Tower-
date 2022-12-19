using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;


public class WaveGenerator : MonoBehaviour
{

    [FoldoutGroup("Variables")] public List<WaveGeneratorData> datas;
    [FoldoutGroup("Variables")] public int currentWaveCount;


    [FoldoutGroup("PositionsLimit"), Space(10f)]

    [TabGroup("PositionsLimit/Locations", "xLimits"), SerializeField] private Vector2 outerX = new(-30, 30);
    [TabGroup("PositionsLimit/Locations", "xLimits"), MinMaxSlider("outerX"), SerializeField] private Vector2 innerX = new(-10, 10);

    [TabGroup("PositionsLimit/Locations", "yLimits"), SerializeField] private Vector2 outerY = new(-30, 30);
    [TabGroup("PositionsLimit/Locations", "yLimits"), MinMaxSlider("outerY"), SerializeField] private Vector2 innerY = new(-10, 10);

    private int spawnCountThisWave = 0;
    private int deadThisWave = 0;


    [Button("Generate Wave")]
    public void GenerateWave()
    {
        spawnCountThisWave = 0;
        deadThisWave = 0;

        int spawnableWave = Mathf.RoundToInt((float)currentWaveCount / 5);

        if (spawnableWave > datas.Count) spawnableWave = datas.Count - 1;

        int hardness = 0;
        int expectedHardness = currentWaveCount * 100;

        for (int i = spawnableWave; i > 0; i--)
        {
            WaveGeneratorData currentData = datas[i - 1];
            int spawnCount = (expectedHardness - hardness) / currentData.hardness;

            spawnCount = currentData.maxSpawnCount != -1 & spawnCount > currentData.maxSpawnCount ? currentData.maxSpawnCount : spawnCount;

            for (int j = 0; j < spawnCount; j++)
            {
                // Obstacle obstacle = Instantiate(currentData.objects, GetRandomSpawnPosition(), Quaternion.identity);
                Obstacle obstacle = ObjectPooling.Instance.GetPooledObject(currentData.objects);

                obstacle.transform.SetPositionAndRotation(GetRandomSpawnPosition(), Quaternion.identity);
                obstacle.gameObject.SetActive(true);

                obstacle.onDead += Check;
            }
            spawnCountThisWave += spawnCount;
        }

        currentWaveCount++;
    }

    private void Check()
    {
        deadThisWave++;
        if (deadThisWave < spawnCountThisWave) return;
        //Generate New Wave
    }
    private Vector2 GetRandomSpawnPosition()
    {
        bool isXUp = Random.Range(0, 2) == 0;
        bool isYUp = Random.Range(0, 2) == 0;

        float x = isXUp ? Random.Range(innerX.y, outerX.y) : Random.Range(outerX.x, innerX.x);
        float y = isYUp ? Random.Range(innerY.y, outerY.y) : Random.Range(outerY.x, innerY.x);

        return new(x, y);
    }
}

[System.Serializable]
public class WaveGeneratorData
{
    public Obstacle objects;

    public int hardness;

    public int maxSpawnCount;
}