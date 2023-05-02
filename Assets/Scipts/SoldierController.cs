using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    CellController cellController;

    public List<GameObject> soldierPrefabs = new List<GameObject>();

    private void Start()
    {
        cellController = GetComponent<CellController>();
    }

    public void SpawnSoldier()
    {
        int index = Random.Range(0,soldierPrefabs.Count);
        GameObject soldier = Instantiate(soldierPrefabs[index]);

        if (cellController.AddSoldier(soldier))
        {

        }
        else
        {
            Debug.Log("Cells is full!");
            Destroy(soldier);
        }
    }
}
