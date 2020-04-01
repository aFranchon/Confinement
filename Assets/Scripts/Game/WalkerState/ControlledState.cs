using UnityEngine;

public class ControlledState : WalkerBaseState
{
    private Material material;

    public override void Start()
    {
        material = new Material(Shader.Find("Diffuse"));
        material.color = Color.blue;
    }

    public override void EnterState(WalkerBehaviour walker)
    {
        walker.gameObject.tag = "Untagged";
        walker.agent.SetDestination(walker.transform.position);
        walker.workerRenderer.material = material;

        foreach (var elem in walker.workerChildRenderer)
        {
            elem.material = material;
        }
    }

    public override void OnCollisionEnter(WalkerBehaviour walker)
    {
    }

    public override void Update(WalkerBehaviour walker)
    {
    }
}
