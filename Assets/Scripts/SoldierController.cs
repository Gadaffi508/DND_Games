using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    CellController cellController;

    public GameObject soldierPrefabs;
    public GameObject MagicPrefabs;

    

    private void Start()
    {
        cellController = GetComponent<CellController>();
    }

    public void SpawnSoldier()
    {

        GameObject soldier = Instantiate(soldierPrefabs);

        if (cellController.AddSoldier(soldier))
        {

        }
        else
        {
            Debug.Log("Cells is full!");
            Destroy(soldier);
        }
    }
    public void SpawnMagic()
    {

        GameObject Magic = Instantiate(MagicPrefabs);

        if (cellController.AddSoldier(Magic))
        {

        }
        else
        {
            Debug.Log("Cells is full!");
            Destroy(Magic);
        }
    }
    
}
