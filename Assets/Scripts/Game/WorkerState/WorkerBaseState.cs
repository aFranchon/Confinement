using UnityEngine;

public abstract class WorkerBaseStat
{
    public abstract void Start();

    public abstract void EnterState(WorkerBehaviour player);

    public abstract void Update(WorkerBehaviour player);

    public abstract void OnCollisionEnter(WorkerBehaviour player, Collision collision);
}
