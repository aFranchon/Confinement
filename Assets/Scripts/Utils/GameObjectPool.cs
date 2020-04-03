using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    #region Fields
    private List<GameObject> pool;

    [SerializeField] private Transform poolContainer;
    [SerializeField] protected GameObject populationPrefab;
    [SerializeField] private int basePopulation;
    #endregion

    #region Initialize Object
    protected virtual void Start()
    {
        pool = GeneratePool();
    }

    private List<GameObject> GeneratePool()
    {
        List<GameObject> newPool = new List<GameObject>();
        GameObject newPopulation;

        for (var i = 0; i < basePopulation; i++)
        {
            newPopulation = Instantiate(populationPrefab, poolContainer);
            newPopulation.SetActive(false);
            newPool.Add(newPopulation);
        }

        return newPool;
    }
    #endregion

    #region Pool methods implementations
    public GameObject RequestPool()
    {
        //finding an elem of the list that is free
        foreach (var population in pool)
        {
            if (!population.gameObject.activeInHierarchy)
            {
                return population;
            }
        }

        //if Any elem are free, just create and add one new to the list and return it

        GameObject newPopulation = Instantiate(populationPrefab, poolContainer);

        pool.Add(newPopulation);

        return newPopulation;
    }
    #endregion
}
