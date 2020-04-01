using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    #region Events
    public event Action onBuyNewWorker;
    public event Action onBuyNewWalkerSpawnRate;
    #endregion
 
    #region Fields
    private WalkerController walkerController;

    [Header("Money infos")]
    public Text moneyText;
    private float money = 0f;

    [Header("Worker number infos")]
    public Text workerNumberText;
    private int workerNumber = 0;
    public Text costWorkerText;
    private int costWorker = 0;

    [Header("Walker spawn rate infos")]
    public Text walkerSpawnRateLevelText;
    private int walkerSpawnRateLevel = 0;
    public Text costWalkerSpawnRateText;
    private int costWalkerSpawnRate = 0;
    #endregion

    #region Starting Object
    // Start is called before the first frame update
    void Awake()
    {
        walkerController = FindObjectOfType<WalkerController>();
    }

    void Start()
    {
        walkerController.walkerControlled += walkerControlled;

        moneyText.text = money.ToString();

        //worker number
        workerNumberText.text = workerNumber.ToString();
        costWalkerSpawnRateText.text = costWalkerSpawnRate.ToString();

        //walker spawn rate
        walkerSpawnRateLevelText.text = walkerSpawnRateLevel.ToString();
        costWalkerSpawnRateText.text = costWalkerSpawnRate.ToString();
    }
    #endregion

    #region Buttons handling
    public void OnButtonClickBuyWorker()
    {
        if (money >= costWorker)
        {
            money -= costWorker;
            workerNumber++;
            costWorker = workerNumber * 5;

            moneyText.text = money.ToString();

            //worker number
            workerNumberText.text = workerNumber.ToString();
            costWorkerText.text = costWorker.ToString();

            onBuyNewWorker?.Invoke();
        }
    }

    public void OnButtonClickBuyWalkerSpawnRate()
    {
        if (money >= costWalkerSpawnRate)
        {
            money -= costWalkerSpawnRate;
            walkerSpawnRateLevel++;
            costWalkerSpawnRate = walkerSpawnRateLevel * 2;

            moneyText.text = money.ToString();
            
            //walker spawn rate
            walkerSpawnRateLevelText.text = walkerSpawnRateLevel.ToString();
            costWalkerSpawnRateText.text = costWalkerSpawnRate.ToString();

            onBuyNewWalkerSpawnRate?.Invoke();
        }
    }
    #endregion

    #region Called by events
    private void walkerControlled()
    {
        money++;

        moneyText.text = money.ToString();
    }
    #endregion
}
