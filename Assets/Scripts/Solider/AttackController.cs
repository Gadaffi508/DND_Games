using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    CellController cellController;
    GameObject[] cellsList;

    private void Awake()
    {
        cellController = GetComponent<CellController>();
        cellsList = GameObject.FindGameObjectsWithTag("Cells");
    }

    public void Attack()
    {
        for (int j = 0; j < cellController.frontCells.Count; j++)
        {
            cellsList[j].GetComponent<Cells>().Atack();
            
        }
    }
}
