using UnityEngine;

public class WorkerController : MonoBehaviour
{
    #region Fields
    [Header("Prefabs")]
    public GameObject workerPrefab;

    private GameController gameController;
    #endregion

    #region Starting Object
    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameController.onBuyNewWorker += createNewWorker;
    }
    #endregion

    #region Logic implementation of the class
    private void createNewWorker()
    {
        var pos = new Vector3(UnityEngine.Random.Range(-50, 50), 0, -UnityEngine.Random.Range(-50, 50));
        //create walker
        var newWalker = Instantiate(workerPrefab, pos, Quaternion.identity);
    }
    #endregion
}
