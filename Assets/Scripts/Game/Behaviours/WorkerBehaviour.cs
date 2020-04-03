using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerBehaviour : MonoBehaviour
{
    #region Field
    public NavMeshAgent agent { get; private set; }
    public Transform nearestWalker { get; private set; }
    public GameObject lastCollision;

    [HideInInspector]
    public Renderer workerRenderer;
    [HideInInspector]
    public Renderer[] workerChildRenderer;

    [Header("Stats")]
    public float aggroRange;
    #endregion

    #region FiniteStateMachine
    private WorkerBaseStat currentState;

    public WorkerBaseStat CurrentState
    {
        get { return currentState; }
    }

    public readonly ControllingState controllingState = new ControllingState();
    public readonly FindingState findingState = new FindingState();

    #endregion

    #region Starting Object
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //workerRenderer = GetComponent<Renderer>();
        //workerChildRenderer = GetComponentsInChildren<Renderer>();
        nearestWalker = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Calling start on all the States
        findingState.Start();
        controllingState.Start();

        TransitionToState(findingState);
        StartCoroutine("getNearestWalker");
    }
    #endregion

    #region Repetitive Methods
    // Update is called once per frame
    void Update()
    {
        //find the nearest walker of the scene
        if (lastCollision && !lastCollision.gameObject.activeInHierarchy)
        {
            Debug.Log("Sould not print more than once in a while");
            lastCollision = null;
        }
        currentState.Update(this);
    }

    private IEnumerator getNearestWalker()
    {
        yield return new WaitForEndOfFrame();

        var walkers = GameObject.FindGameObjectsWithTag("Walker");

        nearestWalker = null;
        float closestDistanceSqr = Mathf.Infinity;

        
        foreach (GameObject potentialNearest in walkers)
        {
            Vector3 directionToTarget = potentialNearest.transform.position - transform.position;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                nearestWalker = potentialNearest.transform;
            }
        }

        yield return new WaitForSeconds(0.1f);
        StartCoroutine("getNearestWalker");
    }
    #endregion

    #region Collisions
    private void OnCollisionEnter(Collision collision)
    {
        //TODO refacto to handle the check in the state directly
        currentState.OnCollisionEnter(this, collision);
    }
    #endregion

    #region StateHandling
    public void TransitionToState(WorkerBaseStat state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    #endregion

    #region Debug Purpose
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
    #endregion
}
