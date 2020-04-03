using UnityEngine;

public class ControllingState : WorkerBaseStat
{
    private Material material;

    public override void Start()
    {
        material = new Material(Shader.Find("Diffuse"));
        material.color = Color.green;
    }
    
    public override void EnterState(WorkerBehaviour worker)
    {
        worker.agent.SetDestination(worker.transform.position);
        
        //old code to change color, not up to date with the new assets
        /*worker.workerRenderer.material = material;

        foreach (var elem in worker.workerChildRenderer)
        {
            elem.material = material;
        }*/
    }

    public override void OnCollisionEnter(WorkerBehaviour worker, Collision collision)
    {
    }

    public override void Update(WorkerBehaviour worker)
    {
        if (!worker.lastCollision)
            worker.TransitionToState(worker.findingState);
    }
}
