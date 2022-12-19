using UnityEngine;


public class MoveState : State
{
    [SerializeField] private State atackState;

    private Transform ParentPosition => transform.parent;
    public override State RunCurrentState(ObstacleData data)
    {
        if (CanAttack(data)) {data.speed = 0f; return atackState; }

        ParentPosition.SetPositionAndRotation(Vector3.MoveTowards(ParentPosition.position, data.target.position, data.speed * Time.deltaTime),
        Quaternion.Euler(LookAtPlayer(data)));

        return this;
    }
    private Vector3 LookAtPlayer(ObstacleData data)
    {
        Vector3 diff = data.target.position - ParentPosition.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        return new(0f, 0f, rot_z - 90);
    }

    private bool CanAttack(ObstacleData data) => Vector2.Distance(ParentPosition.position, data.target.position) < 1f;

}