using System.Collections;
using UnityEngine;
using System;

public class WalkerController : MonoBehaviour
{
    #region Events
    public event Action walkerControlled;
    #endregion

    #region Fields
    [SerializeField] private GameObject walkerPrefab;
    [SerializeField] private GameObjectPool walkerPool;
    private GameController gameController;

    private float walkerSpawnRate = 10f;
    #endregion

    #region Starting Object
    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameController.onBuyNewWalkerSpawnRate += onBuyWalkerSpawnRate;
        StartCoroutine("spawnEnemies");
    }
    #endregion

    #region Repetitive Methods
    private IEnumerator spawnEnemies()
    {
        var pos = new Vector3(UnityEngine.Random.Range(-50, 50), 0, -UnityEngine.Random.Range(-50, 50));
        //create walker
        var newWalker = walkerPool.RequestPool();
        newWalker.SetActive(true);
        newWalker.transform.position = pos;

        //more settings here
        newWalker.GetComponent<WalkerBehaviour>().controlledByWorker += eventControlledWalker;
        
        yield return new WaitForSeconds(walkerSpawnRate);

        StartCoroutine("spawnEnemies");
    }
    #endregion

    #region Called by Events
    private void eventControlledWalker()
    {
        walkerControlled?.Invoke();
    }

    private void onBuyWalkerSpawnRate()
    {
        walkerSpawnRate = walkerSpawnRate * 0.9f;
    }
    #endregion
}
