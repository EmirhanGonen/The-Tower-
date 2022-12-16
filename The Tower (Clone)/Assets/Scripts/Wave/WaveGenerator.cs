using System.Collections.Generic;
using UnityEngine;


public class WaveGenerator : MonoBehaviour
{
    public List<WaveGeneratorData> datas;
    public int currentWaveCount;

    [ContextMenu("Generate Wave")]
    public void GenerateWave()
    {
        int spawnableWave = currentWaveCount / 5;

        if (spawnableWave > datas.Count) spawnableWave = datas.Count;

        int hardness = 0;
        int expectedHardness = currentWaveCount * 100;

        for (int i = spawnableWave; i > 0; i--)
        {
            WaveGeneratorData currentData = datas[i];
            int spawnCount = (expectedHardness - hardness) / currentData.hardness;

            spawnCount = currentData.maxSpawnCount != -1 & spawnCount > currentData.maxSpawnCount ? currentData.maxSpawnCount : spawnCount;

            for (int j = 0; j < spawnCount; j++)
            {
                Instantiate(currentData.objects, Vector3.zero, Quaternion.identity);
            }

        }



        currentWaveCount++;
    }
}

[System.Serializable]
public class WaveGeneratorData
{
    public Obstacle objects;

    public int hardness;

    public int maxSpawnCount;
}