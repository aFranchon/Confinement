using UnityEngine;
using UnityEngine.AI;
using System;

public class WalkerBehaviour : MonoBehaviour
{
    #region Events
    public event Action controlledByWorker;
    #endregion

    #region Fields
    [HideInInspector]
    public NavMeshAgent agent { get; private set; }
    
    [HideInInspector]
    public Renderer workerRenderer;
    [HideInInspector]
    public Renderer[] workerChildRenderer;
    #endregion

    #region FiniteStateMachine
    private WalkerBaseState currentState;

    public WalkerBaseState CurrentState
    {
        get { return currentState; }
    }

    public readonly ControlledState controlledState = new ControlledState();
    public readonly WalkingState walkingState = new WalkingState();

    #endregion

    #region Starting Object
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //workerRenderer = GetComponent<Renderer>();
        //workerChildRenderer = GetComponentsInChildren<Renderer>();
    }

    void Start()
    {
        agent.SetDestination(new Vector3(UnityEngine.Random.Range(-50, 50), 0, -UnityEngine.Random.Range(-50, 50)));

        walkingState.Start();
        controlledState.Start();

        TransitionToState(walkingState);
    }
    #endregion

    #region Collisions
    public void CollidingWithPlayer()
    {
        currentState.OnCollisionEnter(this);
        controlledByWorker?.Invoke();

        //TODO i want to change this, but don't know how
        Destroy(gameObject, 1.5f);
    }
    #endregion

    #region Repetitive Methods
    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }
    #endregion

    #region StateHandling
    public void TransitionToState(WalkerBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    #endregion
}
