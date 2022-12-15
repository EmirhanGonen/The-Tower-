using UnityEngine;


public abstract class UpgradeEnum : ScriptableObject
{
    protected float ratio;
    protected virtual void Upgrade(float data)
    {
        data += ratio;
    }
}