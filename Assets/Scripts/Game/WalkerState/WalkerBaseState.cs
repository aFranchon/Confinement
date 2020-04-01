using UnityEngine;

public abstract class WalkerBaseState
{
    public abstract void Start();

    public abstract void EnterState(WalkerBehaviour walker);

    public abstract void Update(WalkerBehaviour walker);

    public abstract void OnCollisionEnter(WalkerBehaviour walker);
}
