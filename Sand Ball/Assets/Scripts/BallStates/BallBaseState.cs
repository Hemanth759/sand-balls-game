using UnityEngine;

public abstract class BallBaseState
{
    public abstract void EnterState(Balls ball);

    public abstract void OnCollisionEnter(Balls ball, Collision collision);
}
