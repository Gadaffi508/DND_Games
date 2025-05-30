using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    GameManager gameManager;

    public List<Cells> startingCells = new List<Cells>();
    public List<Cells> frontCells = new List<Cells>();

    public List<Cells> allCells = new List<Cells>();

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Gamemanager").gameObject.GetComponent<GameManager>();
    }

    public bool AddSoldier(GameObject soldier) //Asker Spawn
    {
        for (int i = 0; i < startingCells.Count; i++)
        {
            if (startingCells[i].CurrentSoldier == null)
            {
                startingCells[i].CurrentSoldier = soldier;
                return true;
            }
        }
        return false;
    }

    public Cells ContainsCell(GameObject soldier)//Eger mouse pozisyon askerde ise hucreyi movementcontroller scriptine gonderiyoruz
    {
        for (int i = 0; i < allCells.Count; i++)
        {
            if (allCells[i].CurrentSoldier != null && allCells[i].CurrentSoldier == soldier)
            {
                return allCells[i];
            }
        }
        return null;
    }
}
