using UnityEngine;

public class WalkingState : WalkerBaseState
{
    private Material material;

    public override void Start()
    {
        material = new Material(Shader.Find("Diffuse"));
        material.color = Color.red;
    }

    public override void EnterState(WalkerBehaviour walker)
    {
        walker.gameObject.tag = "Walker";
        walker.workerRenderer.material = material;

        foreach (var elem in walker.workerChildRenderer)
        {
            elem.material = material;
        }
    }

    public override void OnCollisionEnter(WalkerBehaviour walker)
    {
        walker.TransitionToState(walker.controlledState);
    }

    public override void Update(WalkerBehaviour walker)
    {
        if (walker.agent.velocity.magnitude == 0)
        {
            var pos = new Vector3(Random.Range(-50, 50), 0, -Random.Range(-50, 50));
            walker.agent.SetDestination(pos);
        }
    }
}
