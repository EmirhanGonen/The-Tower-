using UnityEngine;


public abstract class UpgradeEnum : ScriptableObject
{
    [SerializeField] protected float initializeIncreaseRatio;
    [Range(0, 100)] protected float increaseRatio;

    public virtual void InitializeVariables() => increaseRatio = initializeIncreaseRatio;

    [ContextMenu("Upgrade")]
    public void Upgrade()
    {
        UpgradeLogic();
    }
    protected float IncreaseRatio()
    {
        float multiplyer = increaseRatio / 100;

        return multiplyer;
    }
    protected abstract void UpgradeLogic();
}