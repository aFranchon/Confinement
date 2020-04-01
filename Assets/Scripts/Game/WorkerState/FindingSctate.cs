using UnityEngine;

public class FindingState : WorkerBaseStat
{
    private Material material;

    public override void Start()
    {
        material = new Material(Shader.Find("Diffuse"));
        material.color = Color.black;
    }

    public override void EnterState(WorkerBehaviour worker)
    {
        worker.workerRenderer.material = material;

        foreach (var elem in worker.workerChildRenderer)
        {
            elem.material = material;
        }
    }

    public override void OnCollisionEnter(WorkerBehaviour worker, Collision collision)
    {
        if (collision.gameObject.tag == "Walker" && !worker.lastCollision)
        {
            collision.gameObject.GetComponent<WalkerBehaviour>().CollidingWithPlayer();
            worker.lastCollision = collision.gameObject;
            worker.TransitionToState(worker.controllingState);
        }
    }

    public override void Update(WorkerBehaviour worker)
    {

        Vector3 directionToNearest;
        float distanceToNearest = Mathf.Infinity;

        if (worker.nearestWalker)
        {
            directionToNearest = worker.nearestWalker.transform.position - worker.transform.position;
            distanceToNearest = directionToNearest.magnitude;
        }


        //if player is near enough
        if (distanceToNearest <= worker.aggroRange)
        {
            worker.agent.speed = 40;
            worker.agent.SetDestination(worker.nearestWalker.transform.position);
        }
        //if player is arrived
        else if (worker.agent.velocity.magnitude == 0)
        {
            worker.agent.speed = 20;
            //change destination TODO randomize
            var pos = new Vector3(Random.Range(-50, 50), 0, -Random.Range(-50, 50));
            worker.agent.SetDestination(pos);
        }
    }
}
